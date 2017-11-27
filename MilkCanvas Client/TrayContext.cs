using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Events.Client;

namespace MilkCanvas_Client
{
    public class TrayContext : Form
    {
        private LoginForm Login { get; set; }
        private TwitchClient Client { get; set; }
        private TwitchAPI API { get; set; }
        private ConnectionCredentials Credentials { get; set; }

        private Configuration Config { get; set; }
        private NotifyIcon TrayIcon { get; set; }
        private ContextMenu IconMenu { get; set; }
        private string IconText => "MilkCanvas Client";
        private string AuthenticationEndpoint => "http://localhost/AuthenticationService";

        private bool disposed;

        public TrayContext()
        {
            Initialize();
        }

        private void Initialize()
        {
            Config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            Login = new LoginForm();
            Login.FormClosed += Login_FormClosed;
            Login.TwitchAuthenticated += Login_TwitchAuthenticated;

            IconMenu = new ContextMenu();
            TrayIcon = new NotifyIcon
            {
                ContextMenu = IconMenu,
                Icon = Properties.Resources.MilkIcon,
                Text = IconText,
                Visible = true
            };

            IconMenu.MenuItems.Add("Settings", TrayIcon_Settings);
            IconMenu.MenuItems.Add("Check For Updates", TrayIcon_CheckForUpdates);
            IconMenu.MenuItems.Add("About", TrayIcon_About);
            IconMenu.MenuItems.Add("-");
            IconMenu.MenuItems.Add("Exit", TrayIcon_Exit);

            // FirstLaunch is a special property that handles getting and setting the launch state of the app
            // from the app config. If there is a launch value already saved then this app has been launched before
            // and we need to follow up with a first time setup.
            if (Settings.FirstLaunch)
            {
                // the login form will handle the actual authentication of the user.
                // All we're waiting for is LoginForm to close with a token response.
                Login.Show();
                FirstTimeSetup();
            }
            else
            {
                // TODO: verify saved tokens and login
                // If the tokens are no longer valid, begin first time setup again
            }
        }

        private async void Login_TwitchAuthenticated(object sender, TwitchAuthenticatedEventArgs e)
        {
            API = new TwitchAPI(Properties.Resources.TwitchClient, e.Hash.AccessToken);
            var user = await API.Users.v5.GetUserByIDAsync(e.Hash.Fragment.Subject);

            var credentials = new ConnectionCredentials(user.Name, e.Hash.AccessToken);
            Client = new TwitchClient(credentials, e.Hash.Fragment.Subject);
            Client.OnNewSubscriber += Client_OnNewSubscriber;
            Client.OnReSubscriber += Client_OnReSubscriber;
            Client.OnChatCommandReceived += Client_OnChatCommandReceived;
            Client.OnWhisperCommandReceived += Client_OnWhisperCommandReceived;

            Client.Connect();

            Settings.Save(true, e.Hash.State, e.Hash.Fragment.Subject, e.Hash.AccessToken);
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            // The intended behaviour here is that when the user
            // manually closes the login form, the context will also close
            // - preferably terminating the process.
            if (!Login.FinishedAuthenticator)
            {
                Close();
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

        private void TrayIcon_Exit(object sender, EventArgs e) => Close();
        private void TrayIcon_About(object sender, EventArgs e) => throw new NotImplementedException();
        private void TrayIcon_CheckForUpdates(object sender, EventArgs e) => throw new NotImplementedException();
        private void TrayIcon_Settings(object sender, EventArgs e) => throw new NotImplementedException();

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            base.OnLoad(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // disposed managed state

                TrayIcon?.Dispose();
                IconMenu?.Dispose();

                Client?.Disconnect();
            }

            // dispose unmanaged state

            // unreference values by setting them to null, ensuring that the GC knows we no longer need them.
            TrayIcon = null;
            IconMenu = null;

            Client = null;
            API = null;
            Credentials = null;

            disposed = true;

            base.Dispose(disposing);
        }
    }
}
