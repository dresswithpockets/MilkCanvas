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
    using EdgeJs;
    using MilkCanvas.Enums;
    using MilkCanvas.Events;
    using MilkCanvas.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Handles the initial authentication of the user's preferred streaming service.
    /// </summary>
    public partial class LoginForm : BaseForm
    {
        private string hashFile = "hash";

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public LoginForm()
            : base()
        {
            // we depend on the existence of the hash file as a sort of lock file.
            // If the file exists, we "know" that its contents contain the url fragment
            // generate by the redirect from the twitch API.
            File.Delete(this.hashFile);

            // here we're setting up a service to receive the user's redirect at
            // because there is useful web response from twitch's authentication.
            // Rather, users are automaticaly redirected with the information we need
            // as parameters of the URL.
            var express = Edge.Func(Settings.Scripts.Selfhost);

            express(8080).Wait();

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
        }

        /// <summary>
        /// Raised immediately after authentication has been verified by the login host.
        /// Args provides hash and fragment information about the user and their authentication status.
        /// </summary>
        public event EventHandler<TwitchAuthenticatedEventArgs> TwitchAuthenticated;

        /// <summary>
        /// Gets a value indicating whether or not the authentication has been completed.
        /// </summary>
        public bool FinishedAuthenticator { get; private set; }

        /// <summary>
        /// Gets the social platform that the user is attempting to authenticate with.
        /// Null if the user hasn't selected a platform.
        /// </summary>
        public SocialPlatform? AwaitingPlatform { get; private set; }

        private string State { get; }

        private string Nonce { get; }

        private string TwitchAuthenticationUrl { get; }

        /// <summary>
        /// Verifies validity of the hash response from the host. If the response is valid
        /// then <see cref="TwitchAuthenticated"/> is raised.
        /// </summary>
        /// <param name="hash">The parsed hash data.</param>
        public void SubmitTwitchVerification(TwitchHashFile hash)
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
                // we've verified the response to have valid state and nonce
                // thus we should update with the fragment and close the form.
                this.TwitchAuthenticated?.Invoke(this, new TwitchAuthenticatedEventArgs(hash));
                this.Close();
            }
        }

        private void TwitchConnectButton_Click(object sender, EventArgs e)
        {
            if (this.AwaitingPlatform == null)
            {
                // Since we need the user to actually verify using twitch's flow,
                // we're just going to open the authentication URL in a browser.
                Process.Start(this.TwitchAuthenticationUrl);

                this.AwaitingPlatform = SocialPlatform.Twitch;
            }
        }
    }
}
