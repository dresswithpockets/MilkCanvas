namespace MilkCanvas.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using EdgeJs;
    using MilkCanvas;
    using MilkCanvas.Enums;
    using MilkCanvas.Events;
    using MilkCanvas.Models;

    using Newtonsoft.Json;

    using TwitchLib;
    using TwitchLib.Enums;
    using TwitchLib.Events.Client;
    using TwitchLib.Models.Client;

    using MChatCommand = Models.ChatCommand;
    using STimer = System.Timers.Timer;

    /// <summary>
    /// A context which instantiates a notification icon in the notification tray and initializes contexts with streaming services.
    /// </summary>
    public class TrayContext : Form
    {
        private const string emotePattern = @"\{emote(\d+)\}";

        private bool disposed;
        private List<MChatCommand> chatCommands;
        private List<Command> builtinCommands;
        private List<Alias> aliases;
        private List<Permission> permissions;
        private List<CommandTimeout> timeouts;
        private List<SubscriberEmote> emotes;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrayContext"/> class.
        /// </summary>
        public TrayContext()
        {
            this.Initialize();
        }

        public TwitchAPI API { get; private set; }

        private LoginForm Login { get; set; }

        private GettingStartedForm GettingStarted { get; set; }

        private TwitchClient Client { get; set; }

        private TwitchClient ChatClient { get; set; }

        private ConnectionCredentials Credentials { get; set; }

        private Configuration Config { get; set; }

        private NotifyIcon TrayIcon { get; set; }

        private ContextMenu IconMenu { get; set; }

        private About About { get; set; }

        private Canvas Canvas { get; set; }

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

            this.Credentials = new ConnectionCredentials(user.Name, access);
            this.Client = new TwitchClient(this.Credentials, channel: user.Name);
            this.Client.OnJoinedChannel += this.Client_OnJoinedChannel;
            this.Client.OnNewSubscriber += this.Client_OnNewSubscriber;
            this.Client.OnReSubscriber += this.Client_OnReSubscriber;
            this.Client.OnChatCommandReceived += this.Client_OnChatCommandReceived;
            this.Client.OnGiftedSubscription += this.Client_OnGiftedSubscription;
            this.Client.OnConnectionError += this.Client_OnConnectionError;
            this.Client.OnConnected += this.Client_OnConnected;

            this.Client.Connect();

            var altId = Settings.AltTwitchSubject;
            var altAccess = Settings.AltTwitchAccessToken;
            if (Settings.UseAlternateAccount && altId != null && altAccess != null)
            {
                var creds = new ConnectionCredentials(Utility.GetDisplayNameFromID(this.API, altId), altAccess);
                this.ChatClient = new TwitchClient(creds, channel: user.Name);
                this.ChatClient.Connect();
            }
            else
            {
                this.ChatClient = this.Client;
            }

            if (save)
            {
                Settings.Save(
                    firstLaunch: true,
                    state: state,
                    twitchSubject: subject,
                    twitchAccessToken: access);
            }

            this.Canvas = new Canvas(this);

            HotKeyManager.HotKeyPressed += this.HotKeyManager_HotKeyPressed;
        }

        public MChatCommand FindChatCommand(string identifier)
        {
            return this.chatCommands.FirstOrDefault(c => c.Identifier.Equals(identifier));
        }

        public Command FindBuiltinCommand(string identifier)
        {
            return this.builtinCommands.FirstOrDefault(c => c.Identifier.Equals(identifier));
        }

        public Alias FindAlias(string alias)
        {
            return this.aliases.FirstOrDefault(a => a.Alternate.Equals(alias));
        }

        public bool TryChatCommandFromAlias(Alias alias, out MChatCommand chatCommand)
        {
            chatCommand = this.FindChatCommand(alias?.Command);
            return chatCommand != null;
        }

        public bool TryBuiltinCommandFromAlias(Alias alias, out Command command)
        {
            command = this.FindBuiltinCommand(alias?.Command);
            return command != null;
        }

        public Permission FindPermissionFromCommand(string command)
        {
            return this.permissions.FirstOrDefault(p => p.Command.Equals(command));
        }

        public Permission FindPermissionFromAlias(string aliasIdentifier)
        {
            var alias = this.FindAlias(aliasIdentifier);
            if (this.TryChatCommandFromAlias(alias, out var chatCommand))
            {
                return this.FindPermissionFromCommand(chatCommand.Identifier);
            }

            if (this.TryBuiltinCommandFromAlias(alias, out var command))
            {
                return this.FindPermissionFromCommand(command.Identifier);
            }

            return null;
        }

        public void TimeoutCommand(string command, int? timeout = null)
        {
            var time = 0;
            if (timeout != null)
            {
                time = timeout.Value;
            }
            else
            {
                time = Settings.CommandDelay;
            }

            var timer = new STimer(time * 1000);
            timer.Elapsed += (sender, e) =>
            {
                this.RemoveCommandTimeout(command);
                timer.Stop();
            };
            this.timeouts.Add(new CommandTimeout(command, timer));
            timer.Start();
        }

        public bool CommandTimedout(string command)
        {
            return this.timeouts.FirstOrDefault(t => t.Command.Equals(command)) != null;
        }

        public void RemoveCommandTimeout(string command)
        {
            this.timeouts.Remove(this.timeouts.FirstOrDefault(t => t.Command.Equals(command)));
        }

        public bool ValidPermissions(ChatMessage chat, Permission permission)
        {
            switch (permission?.Group)
            {
                case UserGroup.Broadcaster: return chat.IsBroadcaster;
                case UserGroup.Moderator: return chat.IsBroadcaster || chat.IsModerator;
                case UserGroup.Subscriber: return chat.IsBroadcaster || chat.IsModerator || chat.IsSubscriber;
                case UserGroup.Viewer: return true;
                default: return true;
            }
        }

        public void AlterChatbot(string username, string accessToken)
        {
            var creds = new ConnectionCredentials(username, accessToken);
            this.ChatClient = new TwitchClient(creds, channel: this.Credentials.TwitchUsername);

            this.ChatClient.Connect();
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
                if (this.Client != this.ChatClient)
                {
                    this.ChatClient?.Disconnect();
                }

                this.Login?.Dispose();
                this.GettingStarted?.Dispose();
            }

            // dispose unmanaged state

            // unreference values by setting them to null, ensuring that the GC knows we no longer need them.
            this.TrayIcon = null;
            this.IconMenu = null;
            this.Login = null;
            this.GettingStarted = null;

            this.Client = null;
            this.ChatClient = null;
            this.API = null;
            this.Credentials = null;

            this.disposed = true;

            base.Dispose(disposing);
        }

        private void Initialize()
        {
            if (Settings.ChatCommandsExist)
            {
                this.chatCommands = new List<MChatCommand>(Settings.ChatCommands);
            }
            else
            {
                this.chatCommands = new List<MChatCommand>();
            }

            if (Settings.PermissionsExist)
            {
                this.permissions = new List<Permission>(Settings.Permissions);
            }
            else
            {
                this.permissions = new List<Permission>();
            }

            if (Settings.AliasesExists)
            {
                this.aliases = new List<Alias>(Settings.Aliases);
            }
            else
            {
                this.aliases = new List<Alias>();
            }

            this.timeouts = new List<CommandTimeout>();
            this.emotes = new List<SubscriberEmote>();

            this.SetupBuiltinCommands();

            this.Config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            this.Login = new LoginForm();
            this.Login.FormClosed += this.Login_FormClosed;
            this.Login.TwitchAuthenticated += this.Login_TwitchAuthenticated;

            this.About = new About();

            this.GettingStarted = new GettingStartedForm();

            this.IconMenu = new ContextMenu();
            this.TrayIcon = new NotifyIcon
            {
                ContextMenu = this.IconMenu,
                Icon = Properties.Resources.MilkIcon,
                Text = this.IconText,
                Visible = true,
            };

            // TODO: Auto update system!

            this.IconMenu.MenuItems.Add("Canvas", this.TrayIcon_Canvas);
            this.IconMenu.MenuItems.Add("-");
            this.IconMenu.MenuItems.Add("Import Component Commands", this.TrayIcon_ImportComponentCommands);
            this.IconMenu.MenuItems.Add("About", this.TrayIcon_About);
            this.IconMenu.MenuItems.Add("-");
            this.IconMenu.MenuItems.Add("Exit", this.TrayIcon_Exit);
            this.TrayIcon.DoubleClick += this.TrayIcon_Canvas;

            // here we're setting up a service to receive the user's redirect at
            // because there is useful web response from twitch's authentication.
            // Rather, users are automaticaly redirected with the information we need
            // as parameters of the URL.
            var express = Edge.Func(Settings.Scripts.Selfhost);

            express(8080).Wait();

            // FirstLaunch is a special property that handles getting the launch state of the app
            // from the app config. If there is a launch value already saved then this app has been launched before
            // and we need to follow up with a first time setup.
            if (Settings.FirstLaunch)
            {
                // the login form will handle the actual authentication of the user.
                // All we're waiting for is LoginForm to close with a token response.
                this.Login.Show();
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

        private void SetupBuiltinCommands()
        {
            this.builtinCommands = new List<Command>();
            this.builtinCommands.Add(new Command("uptime", "Prints the current uptime of the stream, if its live.", this.Uptime_ChatCommand));
            this.builtinCommands.Add(new Command("help", "Links to the help document at https://phxvyper.github.io/MilkCanvas", this.Help_ChatCommand));
            this.builtinCommands.Add(new Command("commands", "Prints a list of all of the available commands.", this.Commands_ChatCommand));
            this.builtinCommands.Add(new Command("command", "Handles the creation, deleting and update of chat commands.", this.Command_ChatCommand));
            this.builtinCommands.Add(new Command("alias", "Creates or removes aliases for existing commands.", this.Alias_ChatCommand));
            this.builtinCommands.Add(new Command("permission", "Changes the permissions required to run a command.", this.Permission_ChatCommand));
            this.builtinCommands.Add(new Command("bookmark", "Flags the current timestamp in the stream and saves it.", this.Bookmark_ChatCommand));
        }

        private void SendTaggableMessage(string message, OnChatCommandReceivedArgs args)
        {
            if (args != null)
            {
                var commandArgs = args.Command.ArgumentsAsList;
                var mention = commandArgs.Count > 0 ? commandArgs[commandArgs.Count - 1] : string.Empty;
                if ((args.Command.ChatMessage.IsModerator || args.Command.ChatMessage.IsBroadcaster) && Settings.ModsCanPseudoTag && mention.StartsWith("@"))
                {
                    message = $"{mention} {message}";
                }
                else if (Settings.TagUsers)
                {
                    message = $"@{args.Command.ChatMessage.DisplayName} {message}";
                }
            }

            this.ChatClient.SendMessage(args?.Command.ChatMessage.Channel ?? this.ChatClient.JoinedChannels.First().Channel, message);
        }

        private void CreateBookmark(string username, OnChatCommandReceivedArgs e)
        {
            var id = this.API.GetUserIDAsync(username).GetAwaiter().GetResult();
            var uptime = this.API.GetUptimeAsync(id).GetAwaiter().GetResult();

            if (uptime != null)
            {
                // The description always starts with the first argument.
                var description = e.Command.ArgumentsAsString;

                var sb = new StringBuilder();
                sb.AppendLine($"Description: {description}");
                sb.AppendLine($"Bookmark Date/Time: {DateTimeOffset.Now}");
                sb.AppendLine($"Uptime: {uptime?.ToString().Split('.')[0]}");

                if (!Directory.Exists("./Bookmarks/"))
                {
                    Directory.CreateDirectory("./Bookmarks/");
                }

                Settings.SaveFileText($"./Bookmarks/{description.Substring(0, 32)}", sb.ToString());
                this.TimeoutCommand("bookmark", 15);
            }
            else
            {
                this.SendTaggableMessage("Stream is offline, no bookmark made.", e);
            }
        }

        private string ReplaceEmotes(string message)
        {
            var rand = new Random();

            message.Replace("{emote}", this.emotes[rand.Next(this.emotes.Count)].Code);

            var emotes = new Dictionary<int, string>();
            var matchEmotes = new Regex(emotePattern).Match(message);
            foreach (Group group in matchEmotes.Groups)
            {
                if (group.Success && int.TryParse(group.Value, out var value))
                {
                    // we want to reuse numbers. i.e if the channel has 15 emotes but the user has
                    // {emote20} then thats equivelent to {emote5}.
                    value %= this.emotes.Count;

                    // reuse tags that already have emotes. i.e if we've seen {emote5} before then don't
                    // allocate a new emote for it and just replace it with what we've used before.
                    string emote = string.Empty;
                    if (!emotes.TryGetValue(value, out emote))
                    {
                        // guarantee that the newly allocated emote is unique in the dictionary
                        // so that we're not duplicating the emote in the message.
                        while (!emotes.ContainsValue(emote))
                        {
                            emote = this.emotes[rand.Next(this.emotes.Count)].Code;
                        }

                        emotes.Add(value, emote);
                    }

                    // finally, replace the instance of {emote#} where # is the value with the allocated emote.
                    message.Replace($"{{emote{value}}}", emote);
                }
            }

            return message;
        }

        private void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            this.CreateBookmark(this.Client.ConnectionCredentials.TwitchUsername, null);
        }

        private async void Uptime_ChatCommand(object sender, OnChatCommandReceivedArgs e)
        {
            var response = string.Empty;
            var id = await this.API.GetUserIDAsync(e.Command.ChatMessage.Channel);
            var uptime = await this.API.GetUptimeAsync(id);

            if (uptime != null)
            {
                response = $"Uptime: {uptime?.ToString().Split('.')[0]}";
            }
            else
            {
                response = "Stream is offline!";
            }

            this.SendTaggableMessage(response, e);
        }

        private void Help_ChatCommand(object sender, OnChatCommandReceivedArgs e)
        {
            this.SendTaggableMessage("View Help at https://phxvyper.github.io/MilkCanvas", e);
        }

        private void Commands_ChatCommand(object sender, OnChatCommandReceivedArgs e)
        {
            var commands = this.chatCommands.Select(c => c.Identifier);
            this.ChatClient.SendMessage(e.Command.ChatMessage.Channel, $"Commands: !{string.Join(", !", commands)}");

            // TODO: Integrate with gist and update a gist with a list of all of the commands and aliases. Relay this instead of a full list.
        }

        private void Command_ChatCommand(object sender, OnChatCommandReceivedArgs e)
        {
            // !command {set/clear} {command} {if arg[0] = set: message}
            var args = e.Command.ArgumentsAsList;

            if (args.Count >= 2)
            {
                var action = args[0];
                var alteredCommand = args[1];
                switch (action)
                {
                    case "set":

                        if (args.Count >= 3)
                        {
                            var messageBuilder = new StringBuilder();
                            for (var i = 2; i < args.Count; i++)
                            {
                                messageBuilder.Append(args[i]);
                                messageBuilder.Append(" ");
                            }

                            if (e.Command.ChatMessage.IsBroadcaster || (e.Command.ChatMessage.IsModerator && Settings.ModsSetChatCommands))
                            {
                                // set commands
                                var setCommand = this.FindChatCommand(alteredCommand);
                                if (setCommand != null)
                                {
                                    // the command already exists, so replace it with the updated command.
                                    this.chatCommands.Remove(setCommand);
                                }

                                this.chatCommands.Add(new MChatCommand(alteredCommand, messageBuilder.ToString()));
                                this.ChatClient.SendMessage(e.Command.ChatMessage.Channel, $"Set command: !{alteredCommand}");
                                Settings.SaveCommands(this.chatCommands);
                            }
                        }

                        break;
                    case "clear":

                        if (e.Command.ChatMessage.IsBroadcaster || (e.Command.ChatMessage.IsModerator && Settings.ModsRemoveChatCommands))
                        {
                            var clearedCommand = this.FindChatCommand(alteredCommand);
                            if (clearedCommand != null)
                            {
                                this.chatCommands.Remove(clearedCommand);
                                this.ChatClient.SendMessage(e.Command.ChatMessage.Channel, $"Cleared command: !{alteredCommand}");
                                Settings.SaveCommands(this.chatCommands);
                            }
                        }

                        break;
                }
            }
        }

        private void Alias_ChatCommand(object sender, OnChatCommandReceivedArgs e)
        {
            // !alias {set/clear} {alias} {if arg[0] = set: command}
            var args = e.Command.ArgumentsAsList;

            if (args.Count >= 2)
            {
                var action = args[0];
                var alteredAlias = args[1];
                switch (action)
                {
                    case "set":

                        if (args.Count >= 3)
                        {
                            var otherCommand = args[2];

                            if (e.Command.ChatMessage.IsBroadcaster || (e.Command.ChatMessage.IsModerator && Settings.ModsSetAliases))
                            {
                                // set commands
                                var setAlias = this.FindAlias(alteredAlias);
                                if (setAlias == null)
                                {
                                    // the command doesnt exist, so lets just add a new alias
                                    this.aliases.Add(new Alias(otherCommand, alteredAlias));
                                    this.ChatClient.SendMessage(e.Command.ChatMessage.Channel, $"Added alias: !{alteredAlias} aliases !{otherCommand}");
                                    Settings.SaveAliases(this.aliases);
                                }
                                else
                                {
                                    // the alias already exists, so replace it with the updated alias.
                                    this.aliases.Remove(setAlias);
                                    this.aliases.Add(new Alias(otherCommand, alteredAlias));
                                    this.ChatClient.SendMessage(e.Command.ChatMessage.Channel, $"Updated alias: !{alteredAlias} aliases !{otherCommand}");
                                    Settings.SaveAliases(this.aliases);
                                }
                            }
                        }

                        break;
                    case "clear":

                        if (e.Command.ChatMessage.IsBroadcaster || (e.Command.ChatMessage.IsModerator && Settings.ModsRemoveAliases))
                        {
                            var clearedAlias = this.FindAlias(alteredAlias);
                            if (clearedAlias != null)
                            {
                                this.aliases.Remove(clearedAlias);
                                this.ChatClient.SendMessage(e.Command.ChatMessage.Channel, $"Cleared alias: !{alteredAlias}");
                                Settings.SaveAliases(this.aliases);
                            }
                        }

                        break;
                }
            }
        }

        private void Permission_ChatCommand(object sender, OnChatCommandReceivedArgs e)
        {
            // !permission {command} {group:host|mod|sub|all}
            var args = e.Command.ArgumentsAsList;
            if (args.Count >= 2)
            {
                var permCommand = args[0];
                UserGroup group;
                switch (args[1])
                {
                    case "host":
                        group = UserGroup.Broadcaster;
                        break;
                    case "mod":
                        group = UserGroup.Moderator;
                        break;
                    case "sub":
                        group = UserGroup.Subscriber;
                        break;
                    case "all":
                        group = UserGroup.Viewer;
                        break;
                    default:
                        return;
                }

                var permission = this.FindPermissionFromCommand(permCommand) ?? this.FindPermissionFromAlias(permCommand);
                if (permission != null)
                {
                    this.permissions.Remove(permission);
                }

                this.permissions.Add(new Permission(permCommand, group));

                this.ChatClient.SendMessage(e.Command.ChatMessage.Channel, $"Permissions updated for {permCommand} to {group.ToString()}.");
                Settings.SavePermissions(this.permissions);
            }
        }

        private void Bookmark_ChatCommand(object sender, OnChatCommandReceivedArgs e)
        {
            this.CreateBookmark(e.Command.ChatMessage.Channel, e);
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

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            var subscriptions = JsonConvert.DeserializeObject<Dictionary<string, SubscriberEmotes>>(Utility.Get("https://twitchemotes.com/api_cache/v3/subscriber.json"));

            if (subscriptions.TryGetValue(e.Channel, out var subEmotes))
            {
                this.emotes.AddRange(subEmotes.Emotes);
            }

            // please for the love of god GC clean this bit of memory.
            subscriptions = null;
        }

        private void Client_OnReSubscriber(object sender, OnReSubscriberArgs e)
        {
            if (Settings.UseResubMessage)
            {
                // replace {resubscriber} with subscriber displayname
                // replace {tier} with Twitch Prime, $4.99, $14.99 $24.99
                // replace {length} with months
                // replace {emote#} with random/selected emote
                var message = Settings.ResubMessage;

                var tier = "Twitch Prime";
                if (!(e.ReSubscriber?.IsTwitchPrime ?? false))
                {
                    switch (e.ReSubscriber?.SubscriptionPlan)
                    {
                        case SubscriptionPlan.Tier1:
                            tier = "$4.99";
                            break;
                        case SubscriptionPlan.Tier2:
                            tier = "$14.99";
                            break;
                        case SubscriptionPlan.Tier3:
                            tier = "$24.99";
                            break;
                    }
                }

                message = message.Replace("{resubscriber}", e.ReSubscriber.DisplayName)
                    .Replace("{tier}", tier)
                    .Replace("{length}", $"{e.ReSubscriber.Months} {(e.ReSubscriber.Months == 1 ? "Month" : "Months")}");

                message = this.ReplaceEmotes(message);

                this.ChatClient.SendMessage(e.ReSubscriber.Channel, message);
            }
        }

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            if (Settings.UseSubMessage)
            {
                // replace {subscriber} with subscriber displayname
                // replace {tier} with Twitch Prime, $4.99, $14.99 $24.99
                // replace {emote#} with random/selected emote
                var message = Settings.SubMessage;

                var tier = "Twitch Prime";
                if (!(e.Subscriber?.IsTwitchPrime ?? false))
                {
                    switch (e.Subscriber?.SubscriptionPlan)
                    {
                        case SubscriptionPlan.Tier1:
                            tier = "$4.99";
                            break;
                        case SubscriptionPlan.Tier2:
                            tier = "$14.99";
                            break;
                        case SubscriptionPlan.Tier3:
                            tier = "$24.99";
                            break;
                    }
                }

                // replace each variable with the appropriate values.
                // {emote} specifically will always get a random emote.
                message = message.Replace("{subscriber}", e.Subscriber.DisplayName)
                    .Replace("{tier}", tier);

                message = this.ReplaceEmotes(message);

                this.ChatClient.SendMessage(e.Subscriber.Channel, message);
            }
        }

        private void Client_OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs e)
        {
            if (Settings.UseGiftedSubMessage)
            {
                // TODO: Implement gifted subscription messages. Currently the GiftedSubscription type does not contain the information we need.
            }
        }

        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            // is a valid command only if it exists as an alias or as a command
            dynamic command = null;
            var alias = this.FindAlias(e.Command.CommandText);
            if (alias != null)
            {
                if (this.TryChatCommandFromAlias(alias, out var chatCommand))
                {
                    command = chatCommand;
                }
                else if (this.TryBuiltinCommandFromAlias(alias, out var builtinCommand))
                {
                    command = builtinCommand;
                }
            }
            else
            {
                command = this.FindChatCommand(e.Command.CommandText);

                if (command == null)
                {
                    command = this.FindBuiltinCommand(e.Command.CommandText);
                }
            }

            if (command != null && this.ValidPermissions(e.Command.ChatMessage, this.FindPermissionFromCommand(command.Identifier)))
            {
                // we've confirmed its a valid command and the user has permissions, thus we can begin executing it.

                // we can ignore the command delay if the user is a mod or the broadcaster, we're only worried about
                // spam from regular viewers and maybe subscribers.
                var ignoreDelay = e.Command.ChatMessage.IsBroadcaster || (e.Command.ChatMessage.IsModerator && Settings.ExemptModsFromDelay) || !Settings.UseCommandDelay;

                if (ignoreDelay || !this.CommandTimedout(e.Command.CommandText))
                {
                    if (command is Command builtinCommand)
                    {
                        builtinCommand.Callback?.Invoke(this, e);
                    }
                    else if (command is MChatCommand chatCommand)
                    {
                        this.SendTaggableMessage(chatCommand.Message, e);
                    }

                    if (!ignoreDelay)
                    {
                        this.TimeoutCommand(e.Command.CommandText);
                    }
                }
            }
        }

        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs args)
        {
            if (Settings.ReconnectCanvas)
            {
                this.TrayIcon.Text = "Connection Error... Reconnecting";

                var delay = Settings.ReconnectDelay;
                if (delay < 0)
                {
                    delay *= -1;
                }

                var t = new STimer(delay * 1000);
                t.Elapsed += (s, e) =>
                {
                    this.TwitchSetup(Properties.Resources.TwitchClient, Settings.TwitchAccessToken, Settings.TwitchSubject, Settings.State, save: false);
                    t.Stop();
                };
                t.Start();
            }
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            this.TrayIcon.Text = "Connected.";
        }

        private void TrayIcon_Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrayIcon_About(object sender, EventArgs e)
        {
            this.About.Show();
        }

        private void TrayIcon_ImportComponentCommands(object sender, EventArgs e)
        {
            using (var fileBrowser = new OpenFileDialog())
            {
                fileBrowser.CheckFileExists = true;
                fileBrowser.CheckPathExists = true;
                fileBrowser.Multiselect = false;
                fileBrowser.Filter = "Component Commands (ComponentSettings.xml)|ComponentSettings.xml";

                var result = fileBrowser.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var commands = from command in XDocument.Load(fileBrowser.FileName).Descendants("Command")
                                   select new MChatCommand((string)command.Element("Name"), (string)command.Element("Message"));

                    this.chatCommands.AddRange(commands);
                    Settings.SaveCommands(this.chatCommands);
                    MessageBox.Show(this, "Finished importing chat commands.\nType !commands in chat to see what was imported.", "Finished", MessageBoxButtons.OK);
                }
            }
        }

        private void TrayIcon_Canvas(object sender, EventArgs e)
        {
            this.Canvas.Show();
        }
    }
}
