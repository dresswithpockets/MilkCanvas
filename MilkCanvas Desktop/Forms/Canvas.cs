namespace MilkCanvas.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using MilkCanvas.Enums;
    using MilkCanvas.Events;
    using MilkCanvas.Models;
    using Newtonsoft.Json;
    using TwitchLib;

    public partial class Canvas : BaseForm
    {
        private string hashFile = "hash";
        private int? hotkey;
        private TrayContext context;

        public Canvas(TrayContext context)
        {
            this.context = context;

            // we depend on the existence of the hash file as a sort of lock file.
            // If the file exists, we "know" that its contents contain the url fragment
            // generate by the redirect from the twitch API.
            File.Delete(this.hashFile);

            // nonce is a verification value used to avoid replay attacks in OpenID.
            // state is a token used to avoid replay attacks in OAuth.
            // any party can respond with a nonce and state, mismatched values will result in failure.
            this.Nonce = Guid.NewGuid().ToString();
            this.State = Guid.NewGuid().ToString();
            this.AwaitingPlatform = null;

            // this flow is based off of the what Twitch describes here: https://dev.twitch.tv/docs/authentication#oidc-implicit-code-flow-id-tokens-and-optional-user-access-tokens
            this.TwitchAuthenticationUrl = $"https://api.twitch.tv/kraken/oauth2/authorize" +
                    $"?client_id={Properties.Resources.TwitchClient}" +
                    $"&redirect_uri=http://localhost:8080/twitch" +
                    $"&response_type=token+id_token" +
                    $"&scope={Properties.Resources.TwitchScope}" +
                    $"&nonce={this.Nonce}" +
                    $"&state={this.State}";

            this.InitializeComponent();

            this.SetupGeneralSettings();
            this.SetupTagginSettings();
            this.SetupPermissionsSettings();
            this.SetupBookmarkSettings();
        }

        /// <summary>
        /// Gets the social platform that the user is attempting to authenticate with.
        /// Null if the user hasn't selected a platform.
        /// </summary>
        public SocialPlatform? AwaitingPlatform { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the authentication has been completed.
        /// </summary>
        private bool FinishedAuthenticator { get; set; }

        private string State { get; }

        private string Nonce { get; }

        private string TwitchAuthenticationUrl { get; }

        protected override void ActionBar_OnCloseRequested(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SetupGeneralSettings()
        {
            this.chatBotCheckbox.Checked = Settings.UseAlternateAccount;
            this.subMessageCheckbox.Checked = Settings.UseSubMessage;
            this.resubMessageCheckbox.Checked = Settings.UseResubMessage;
            this.commandDelayCheckbox.Checked = Settings.UseCommandDelay;
            this.reconnectCheckbox.Checked = Settings.ReconnectCanvas;

            this.subMessageText.Text = Settings.SubMessage;
            this.resubMessageText.Text = Settings.ResubMessage;
            this.timeoutNumeric.Value = Settings.CommandDelay;
            this.reconnectNumeric.Value = Settings.ReconnectDelay;

            this.altAccountLogin.Enabled = this.chatBotCheckbox.Checked;
            this.subMessageText.Enabled = this.subMessageCheckbox.Checked;
            this.resubMessageText.Enabled = this.resubMessageCheckbox.Checked;
            this.timeoutNumeric.Enabled = this.commandDelayCheckbox.Checked;
            this.reconnectNumeric.Enabled = this.reconnectCheckbox.Checked;

            this.altAccountNameLabel.Text = string.Empty;
            var altId = Settings.AltTwitchSubject;
            if (this.chatBotCheckbox.Checked && altId != null)
            {
                this.altAccountNameLabel.Visible = true;
                this.altAccountLabel.Visible = true;
                this.altAccountNameLabel.Text = Utility.GetDisplayNameFromID(this.context.API, altId);
            }
        }

        private void SetupTagginSettings()
        {
            this.tagUsersCheckbox.Checked = Settings.TagUsers;
            this.modsPseudoTagUsersCheckbox.Checked = Settings.ModsCanPseudoTag;
        }

        private void SetupPermissionsSettings()
        {
            this.exemptModsDelayCheckbox.Checked = Settings.ExemptModsFromDelay;
            this.modsSetCommandsCheckbox.Checked = Settings.ModsSetChatCommands;
            this.modsRemoveCommandsCheckbox.Checked = Settings.ModsRemoveChatCommands;
            this.modsSetAliasesCheckbox.Checked = Settings.ModsSetAliases;
            this.modsRemoveAliasesCheckbox.Checked = Settings.ModsRemoveAliases;
        }

        private void SetupBookmarkSettings()
        {
            this.hotkeyComboBox.Items.AddRange(Enum.GetNames(typeof(Keys)));

            this.useBookmarkHotkeyCheckbox.Checked = Settings.UseBookmarkHotkey;

            var modifier = (KeyModifiers)Settings.BookmarkModifiers;
            var key = (Keys)Settings.BookmarkHotkey;
            this.controlCheckbox.Checked = (modifier & KeyModifiers.Control) == KeyModifiers.Control;
            this.altCheckbox.Checked = (modifier & KeyModifiers.Alt) == KeyModifiers.Alt;
            this.shiftCheckbox.Checked = (modifier & KeyModifiers.Shift) == KeyModifiers.Shift;

            for (var i = 0; i < this.hotkeyComboBox.Items.Count; i++)
            {
                var item = this.hotkeyComboBox.Items[i];
                if (item.ToString() == ((Keys)Settings.BookmarkHotkey).ToString())
                {
                    this.hotkeyComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SubmitTwitchVerification(TwitchHashFile hash)
        {
            if (this.AwaitingPlatform != SocialPlatform.Twitch)
            {
                // Decline the request to submit this fragment since we're not waiting for it.
                return;
            }

            var hostState = this.State.Trim().ToLower();
            var hostNonce = this.Nonce.Trim().ToLower();
            var clientState = hash.State.Trim().ToLower();
            var clientNonce = hash.Fragment.Nonce.Trim().ToLower();
            if (!hostState.Equals(clientState) || !hostNonce.Equals(clientNonce))
            {
                MessageBox.Show(
                    "An invalid response was received at our endpoint.\n" +
                    "It is possible a third party is attempting to get access to your authenticated token.\n" +
                    "Due to the risk of this possiblity, we are forcing the application to crash.\n" +
                    "This will generate new state tokens for verification.\n\n", "There was a critical exception.");

                Application.Exit();
            }
            else
            {
                this.altAccountLabel.Visible = true;
                this.altAccountNameLabel.Visible = true;
                this.altAccountNameLabel.Text = Utility.GetDisplayNameFromID(this.context.API, hash.Fragment.Subject);
                this.context.AlterChatbot(this.altAccountNameLabel.Text, hash.AccessToken);
                Settings.Save(altTwitchSubject: hash.Fragment.Subject, altTwitchAccessToken: hash.AccessToken);
            }
        }

        private void ChatBotCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(useAltAccount: this.altAccountLogin.Enabled = this.chatBotCheckbox.Checked);
        }

        private void SubMessageCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(useSubMessage: this.subMessageText.Enabled = this.subMessageCheckbox.Checked);
        }

        private void ResubMessageCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(useResubMessage: this.resubMessageText.Enabled = this.resubMessageCheckbox.Checked);
        }

        private void CommandDelayCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(useCommandDelay: this.timeoutNumeric.Enabled = this.commandDelayCheckbox.Checked);
        }

        private void ReconnectCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(reconnectCanvas: this.reconnectNumeric.Enabled = this.reconnectCheckbox.Checked);
        }

        private void AltAccountLogin_Click(object sender, EventArgs e)
        {
            if (this.AwaitingPlatform == null)
            {
                // Since we need the user to actually verify using twitch's flow,
                // we're just going to open the authentication URL in a browser.
                Process.Start(this.TwitchAuthenticationUrl);

                this.AwaitingPlatform = SocialPlatform.Twitch;

                // Run as a task so it doesn't block
                Task.Run(() =>
                {
                    // once we've determined that this hash lock file exists, we need to use
                    // its contents to obtain something useful.
                    while (!Settings.FileReady(this.hashFile))
                    {
                    }

                    switch (this.AwaitingPlatform)
                    {
                        case SocialPlatform.Twitch: return JsonConvert.DeserializeObject<TwitchHashFile>(Settings.ReadFileText(this.hashFile));
                        case SocialPlatform.Mixer: return null; // TODO: mixer integration
                        case SocialPlatform.YouTube: return null; // TODO: youtube integration
                        default: return null;
                    }
                }).ContinueWith(t =>
                {
                    this.Invoke(new Action(() =>
                    {
                        // TODO: submit verification for mixer and youtube
                        this.FinishedAuthenticator = true;
                        this.SubmitTwitchVerification(t.Result);
                    }));
                });
            }
        }

        private void SubMessageText_TextChanged(object sender, EventArgs e)
        {
            Settings.Save(subMessage: this.subMessageText.Text);
        }

        private void ResubMessageText_TextChanged(object sender, EventArgs e)
        {
            Settings.Save(resubMessage: this.resubMessageText.Text);
        }

        private void TimeoutNumeric_ValueChanged(object sender, EventArgs e)
        {
            Settings.Save(commandDelay: Convert.ToInt32(this.timeoutNumeric.Value));
        }

        private void ReconnectNumeric_ValueChanged(object sender, EventArgs e)
        {
            Settings.Save(reconnectDelay: Convert.ToInt32(this.reconnectNumeric.Value));
        }

        private void HelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://phxvyper.github.io/MilkCanvas");
        }

        private void ModsPseudoTagHelpLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://phxvyper.github.io/MilkCanvas#Moderators-Can-Pseudo-Tag-Users");
        }

        private void TagUsersCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(tagUsers: this.tagUsersCheckbox.Checked);
        }

        private void ModsPseudoTagUsersCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(modsCanPseudoTag: this.modsPseudoTagUsersCheckbox.Checked);
        }

        private void ExemptModsDelayCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(exemptModsFromDelay: this.exemptModsDelayCheckbox.Checked);
        }

        private void ModsSetCommandsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(modsSetChatCommands: this.modsSetCommandsCheckbox.Checked);
        }

        private void ModsRemoveCommandsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(modsRemoveChatCommands: this.modsRemoveCommandsCheckbox.Checked);
        }

        private void ModsSetAliasesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(modsSetAliases: this.modsSetAliasesCheckbox.Checked);
        }

        private void ModsRemoveAliasesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Save(modsRemoveAliases: this.modsSetAliasesCheckbox.Checked);
        }

        private void UseBookmarkHotkeyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var value = this.useBookmarkHotkeyCheckbox.Checked;
            this.controlCheckbox.Enabled = value;
            this.altCheckbox.Enabled = value;
            this.shiftCheckbox.Enabled = value;
            this.hotkeyComboBox.Enabled = value;
            Settings.Save(useBookmarkHotkey: value);
        }

        private void UpdateHotkey(object sender, EventArgs e)
        {
            var modifier = (KeyModifiers)0;

            if (this.controlCheckbox.Checked)
            {
                modifier |= KeyModifiers.Control;
            }

            if (this.altCheckbox.Checked)
            {
                modifier |= KeyModifiers.Alt;
            }

            if (this.shiftCheckbox.Checked)
            {
                modifier |= KeyModifiers.Shift;
            }

            int? key = null;
            if (Enum.TryParse<Keys>(this.hotkeyComboBox.SelectedItem as string, true, out var value))
            {
                key = (int)value;
            }

            Settings.Save(bookmarkModifiers: (int)modifier, bookmarkHotkey: key);

            if (this.hotkey != null)
            {
                HotKeyManager.UnregisterHotKey(this.hotkey.Value);
            }

            if (key != null)
            {
                this.hotkey = HotKeyManager.RegisterHotKey((Keys)key.Value, modifier);
            }
        }
    }
}