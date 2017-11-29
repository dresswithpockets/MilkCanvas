namespace MilkCanvas.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using MilkCanvas;
    using MilkCanvas.Controls;
    using MilkCanvas.Events;

    using TwitchLib;
    using TwitchLib.Events.Client;
    using TwitchLib.Models.Client;

    /// <summary>
    /// A context which instantiates a notification icon in the notification tray and initializes contexts with streaming services.
    /// </summary>
    public class TrayContext : Form
    {
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrayContext"/> class.
        /// </summary>
        public TrayContext()
        {
            this.Initialize();
        }

        private LoginForm Login { get; set; }

        private TwitchClient Client { get; set; }

        private TwitchAPI API { get; set; }

        private ConnectionCredentials Credentials { get; set; }

        private Configuration Config { get; set; }

        private NotifyIcon TrayIcon { get; set; }

        private ContextMenu IconMenu { get; set; }

        private string IconText => "MilkCanvas Client";

        private string AuthenticationEndpoint => "http://localhost/AuthenticationService";

        /// <summary>
        /// Initialize the Twitch context.
        /// </summary>
        /// <param name="twitchClient">A developer application client id.</param>
        /// <param name="access">A user access token.</param>
        /// <param name="subject">The userid of a user received by a fragment.</param>
        /// <param name="state">The state string verified by the host.</param>
        /// <param name="save">Whether or not to save the aforementioned parameters in the app settings.</param>
        public async void TwitchSetup(string twitchClient, string access, string subject, string state, bool save = true)
        {
            this.API = new TwitchAPI(twitchClient, access);
            var user = await this.API.Users.v5.GetUserByIDAsync(subject);

            var credentials = new ConnectionCredentials(user.Name, access);
            this.Client = new TwitchClient(credentials, channel: user.Name);
            this.Client.OnNewSubscriber += this.Client_OnNewSubscriber;
            this.Client.OnReSubscriber += this.Client_OnReSubscriber;
            this.Client.OnChatCommandReceived += this.Client_OnChatCommandReceived;
            this.Client.OnWhisperCommandReceived += this.Client_OnWhisperCommandReceived;

            this.Client.Connect();

            if (save)
            {
                Settings.Save(true, state, subject, access);
            }
        }

        /// <summary>
        /// Informs all resources and contexts to terminate safely and dispose.
        /// </summary>
        public new void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Raises the <see cref="Form.Load"/> event.
        /// </summary>
        /// <param name="e">Args passed by the raised event.</param>
        protected override void OnLoad(EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;

            base.OnLoad(e);
        }

        /// <summary>
        /// Informs all resources and contexts to terminate safely and dispose, then ends all references to disposed objects.
        /// </summary>
        /// <param name="disposing">Whether or not to terimate and dispose managed resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                // disposed managed state
                this.TrayIcon?.Dispose();
                this.IconMenu?.Dispose();

                this.Client?.Disconnect();
            }

            // dispose unmanaged state

            // unreference values by setting them to null, ensuring that the GC knows we no longer need them.
            this.TrayIcon = null;
            this.IconMenu = null;

            this.Client = null;
            this.API = null;
            this.Credentials = null;

            this.disposed = true;

            base.Dispose(disposing);
        }

        private void Initialize()
        {
            this.Config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            this.Login = new LoginForm();
            this.Login.FormClosed += this.Login_FormClosed;
            this.Login.TwitchAuthenticated += this.Login_TwitchAuthenticated;

            this.IconMenu = new ContextMenu();
            this.TrayIcon = new NotifyIcon
            {
                ContextMenu = this.IconMenu,
                Icon = Properties.Resources.MilkIcon,
                Text = this.IconText,
                Visible = true,
            };

            this.IconMenu.MenuItems.Add("Settings", this.TrayIcon_Settings);
            this.IconMenu.MenuItems.Add("Check For Updates", this.TrayIcon_CheckForUpdates);
            this.IconMenu.MenuItems.Add("About", this.TrayIcon_About);
            this.IconMenu.MenuItems.Add("-");
            this.IconMenu.MenuItems.Add("Exit", this.TrayIcon_Exit);

            // FirstLaunch is a special property that handles getting and setting the launch state of the app
            // from the app config. If there is a launch value already saved then this app has been launched before
            // and we need to follow up with a first time setup.
            if (Settings.FirstLaunch)
            {
                // the login form will handle the actual authentication of the user.
                // All we're waiting for is LoginForm to close with a token response.
                this.Login.Show();

                this.FirstTimeSetup();
            }
            else
            {
                // We don't utilize Login here because we're expecting that the saved info is accurate.
                // which tbh is pretty bad and we need to handle a case where this info is no longer accurate (like if
                // the user disconnected their account from the MilkCanvas dev application).
                //
                // save: false because we're pulling these from the saved settings, so why would we save them again?
                this.TwitchSetup(Properties.Resources.TwitchClient, Settings.TwitchAccessToken, Settings.TwitchSubject, Settings.State, save: false);
            }
        }

        private void Login_TwitchAuthenticated(object sender, TwitchAuthenticatedEventArgs e)
        {
            this.TwitchSetup(Properties.Resources.TwitchClient, e.Hash.AccessToken, e.Hash.Fragment.Subject, e.Hash.State, true);
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            // The intended behaviour here is that when the user
            // manually closes the login form, the context will also close
            // - preferably terminating the process.
            if (!this.Login.FinishedAuthenticator)
            {
                this.Close();
            }
        }

        private void AuthenticateTwitch(string idToken, string scope, string state, string nonce)
        {
            MessageBox.Show("Wow!");
        }

        private void FirstTimeSetup()
        {
            // Show first-time short guide after getting logged in.
            // Ask if the user wants to use their account or another account for the chat bot.
            // if the user wants to use another account, have them sign in with the other account.
        }

        private void Client_OnReSubscriber(object sender, OnReSubscriberArgs e) => throw new NotImplementedException();

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e) => throw new NotImplementedException();

        private void Client_OnWhisperCommandReceived(object sender, OnWhisperCommandReceivedArgs e) => throw new NotImplementedException();

        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e) => throw new NotImplementedException();

        private void TrayIcon_Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrayIcon_About(object sender, EventArgs e) => throw new NotImplementedException();

        private void TrayIcon_CheckForUpdates(object sender, EventArgs e) => throw new NotImplementedException();

        private void TrayIcon_Settings(object sender, EventArgs e) => throw new NotImplementedException();
    }
}
