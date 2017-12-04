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

            this.InitializeComponent();

            this.SetupGeneralSettings();
            this.SetupTagginSettings();
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
    }
}
