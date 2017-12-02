namespace MilkCanvas
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using MilkCanvas.Models;

    using Newtonsoft.Json;

    public static class Settings
    {
        private const string chatCommandsPath = "commands.json";
        private const string permissionsPath = "permissions.json";
        private const string aliasesPath = "aliases.json";
        private const string launchedKey = "Launched";
        private const string stateKey = "State";
        private const string twitchSubjectKey = "TwitchSubject";
        private const string twitchAccessTokenKey = "TwitchAccessToken";

        private const string useAlternateAccountKey = "UseAlternateAccount";
        private const string altTwitchSubjectKey = "AltTwitchSubject";
        private const string altTwitchAccessTokenKey = "AltTwitchAccessToken";
        private const string useSubMessageKey = "UseSubMessage";
        private const string subMessageKey = "SubMessage";
        private const string useResubMessageKey = "UseResubMessage";
        private const string resubMessageKey = "ResubMessage";
        private const string useGiftedSubMessageKey = "UseGiftedSubMessage";
        private const string giftedSubMessageKey = "GiftedSubMessage";
        private const string useCommandDelayKey = "UseCommandDelay";
        private const string commandDelayKey = "CommandDelay";
        private const string reconnectCanvasKey = "ReconnectCanvas";
        private const string reconnectDelayKey = "ReconnectDelay";

        private const string exemptModsFromDelayKey = "ExemptModsFromDelay";
        private const string modsSetChatCommandsKey = "ModsSetChatCommands";
        private const string modsRemoveChatCommandsKey = "ModsRemoveChatCommands";
        private const string modsSetAliasesKey = "ModsSetAliases";
        private const string modsRemoveAliasesKey = "ModsRemoveAliases";

        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

        private static readonly Lazy<ChatCommand[]> chatCommands = new Lazy<ChatCommand[]>(() => JsonConvert.DeserializeObject<ChatCommand[]>(ReadFileText(chatCommandsPath), new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
        private static readonly Lazy<Permission[]> permissions = new Lazy<Permission[]>(() => JsonConvert.DeserializeObject<Permission[]>(ReadFileText(permissionsPath)));
        private static readonly Lazy<Alias[]> aliases = new Lazy<Alias[]>(() => JsonConvert.DeserializeObject<Alias[]>(ReadFileText(aliasesPath)));

        public static ChatCommand[] ChatCommands => chatCommands.Value;

        public static Permission[] Permissions => permissions.Value;

        public static Alias[] Aliases => aliases.Value;

        public static bool ChatCommandsExist => File.Exists(chatCommandsPath);

        public static bool PermissionsExist => File.Exists(permissionsPath);

        public static bool AliasesExists => File.Exists(aliasesPath);

        public static bool FirstLaunch => GetSetting(launchedKey) == null;

        public static string State
        {
            get
            {
                var setting = GetSetting(stateKey);
                if (setting != null)
                {
                    return setting.Value;
                }

                return null;
            }
        }

        public static string TwitchSubject
        {
            get
            {
                var setting = GetSetting(twitchSubjectKey);
                if (setting != null)
                {
                    return setting.Value;
                }

                return null;
            }
        }

        public static string TwitchAccessToken
        {
            get
            {
                var setting = GetSetting(twitchAccessTokenKey);
                if (setting != null)
                {
                    return setting.Value;
                }

                return null;
            }
        }

        public static bool UseAlternateAccount
        {
            get
            {
                var setting = GetSetting(useAlternateAccountKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static string AltTwitchSubject
        {
            get
            {
                var setting = GetSetting(altTwitchSubjectKey);
                if (setting != null)
                {
                    return setting.Value;
                }

                return null;
            }
        }

        public static string AltTwitchAccessToken
        {
            get
            {
                var setting = GetSetting(altTwitchAccessTokenKey);
                if (setting != null)
                {
                    return setting.Value;
                }

                return null;
            }
        }

        public static bool UseSubMessage
        {
            get
            {
                var setting = GetSetting(useSubMessageKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static string SubMessage
        {
            get
            {
                var setting = GetSetting(subMessageKey);
                if (setting != null)
                {
                    return setting.Value;
                }

                return null;
            }
        }

        public static bool UseResubMessage
        {
            get
            {
                var setting = GetSetting(useResubMessageKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static string ResubMessage
        {
            get
            {
                var setting = GetSetting(resubMessageKey);
                if (setting != null)
                {
                    return setting.Value;
                }

                return null;
            }
        }

        public static bool UseGiftedSubMessage
        {
            get
            {
                var setting = GetSetting(useGiftedSubMessageKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static string GiftedSubMessage
        {
            get
            {
                var setting = GetSetting(giftedSubMessageKey);
                if (setting != null)
                {
                    return setting.Value;
                }

                return null;
            }
        }

        public static bool UseCommandDelay
        {
            get
            {
                var setting = GetSetting(useCommandDelayKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static int CommandDelay
        {
            get
            {
                var setting = GetSetting(commandDelayKey);
                if (setting != null && int.TryParse(setting.Value, out var value))
                {
                    return value;
                }

                return 0;
            }
        }

        public static bool ReconnectCanvas
        {
            get
            {
                var setting = GetSetting(reconnectCanvasKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static int ReconnectDelay
        {
            get
            {
                var setting = GetSetting(reconnectDelayKey);
                if (setting != null && int.TryParse(setting.Value, out var value))
                {
                    return value;
                }

                return 0;
            }
        }

        public static bool ExemptModsFromDelay
        {
            get
            {
                var setting = GetSetting(exemptModsFromDelayKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static bool ModsSetChatCommands
        {
            get
            {
                var setting = GetSetting(modsSetChatCommandsKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static bool ModsRemoveChatCommands
        {
            get
            {
                var setting = GetSetting(modsRemoveChatCommandsKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static bool ModsSetAliases
        {
            get
            {
                var setting = GetSetting(modsSetAliasesKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static bool ModsRemoveAliases
        {
            get
            {
                var setting = GetSetting(modsRemoveAliasesKey);
                if (setting != null)
                {
                    return bool.TrueString.Equals(setting.Value);
                }

                return false;
            }
        }

        public static KeyValueConfigurationElement GetSetting(string key) => config.AppSettings.Settings[key];

        public static void Save(
            bool? firstLaunch = null,
            string state = null,
            string twitchSubject = null,
            string twitchAccessToken = null,
            bool? useAltAccount = null,
            string altTwitchSubject = null,
            string altTwitchAccessToken = null,
            bool? useSubMessage = null,
            string subMessage = null,
            bool? useResubMessage = null,
            string resubMessage = null,
            bool? useGiftedSubMessage = null,
            string giftedSubMessage = null,
            bool? useCommandDelay = null,
            int? commandDelay = null,
            bool? reconnectCanvas = null,
            int? reconnectDelay = null,
            bool? exemptModsFromDelay = null,
            bool? modsSetChatCommands = null,
            bool? modsRemoveChatCommands = null,
            bool? modsSetAliases = null,
            bool? modsRemoveAliases = null)
        {

            // launch options
            if (firstLaunch != null)
            {
                UpdateSetting(launchedKey, firstLaunch.Value.ToString());
            }

            if (state != null)
            {
                UpdateSetting(stateKey, state);
            }

            if (twitchSubject != null)
            {
                UpdateSetting(twitchSubjectKey, twitchSubject);
            }

            if (twitchAccessToken != null)
            {
                UpdateSetting(twitchAccessTokenKey, twitchAccessToken);
            }

            // general options
            if (useAltAccount != null)
            {
                UpdateSetting(useAlternateAccountKey, useAltAccount.Value.ToString());
            }

            if (altTwitchSubject != null)
            {
                UpdateSetting(altTwitchSubjectKey, altTwitchSubject);
            }

            if (altTwitchAccessToken != null)
            {
                UpdateSetting(altTwitchAccessTokenKey, altTwitchAccessToken);
            }

            if (useSubMessage != null)
            {
                UpdateSetting(useSubMessageKey, useSubMessage.Value.ToString());
            }

            if (subMessage != null)
            {
                UpdateSetting(subMessageKey, subMessage);
            }

            if (useResubMessage != null)
            {
                UpdateSetting(useResubMessageKey, useResubMessage.Value.ToString());
            }

            if (resubMessage != null)
            {
                UpdateSetting(resubMessageKey, resubMessage);
            }

            if (useGiftedSubMessage != null)
            {
                UpdateSetting(useGiftedSubMessageKey, useGiftedSubMessage.Value.ToString());
            }

            if (giftedSubMessage != null)
            {
                UpdateSetting(giftedSubMessageKey, giftedSubMessage);
            }

            if (useCommandDelay != null)
            {
                UpdateSetting(useCommandDelayKey, useCommandDelay.Value.ToString());
            }

            if (commandDelay != null)
            {
                UpdateSetting(commandDelayKey, commandDelay.Value.ToString());
            }

            if (reconnectCanvas != null)
            {
                UpdateSetting(reconnectCanvasKey, reconnectCanvas.Value.ToString());
            }

            if (reconnectDelay != null)
            {
                UpdateSetting(reconnectDelayKey, reconnectDelay.Value.ToString());
            }

            config.Save();
        }

        public static void SaveCommands(List<ChatCommand> cmds)
        {
            SaveFileText(chatCommandsPath, JsonConvert.SerializeObject(cmds));
        }

        public static void SavePermissions(List<Permission> permissions)
        {
            SaveFileText(permissionsPath, JsonConvert.SerializeObject(permissions));
        }

        public static void SaveAliases(List<Alias> aliases)
        {
            SaveFileText(aliasesPath, JsonConvert.SerializeObject(aliases));
        }

        public static void UpdateIf(bool assertion, string key, string value)
        {
            if (assertion)
            {
                UpdateSetting(key, value);
            }
        }

        public static void UpdateSetting(string key, string value)
        {
            var setting = GetSetting(key);
            if (setting != null)
            {
                config.AppSettings.Settings[key].Value = value;
            }
            else
            {
                config.AppSettings.Settings.Add(key, value);
            }
        }

        public static string ReadFileText(string path)
        {
            using (var file = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(file))
            {
                return reader.ReadToEnd();
            }
        }

        public static void SaveFileText(string path, string text)
        {
            using (var file = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(file))
            {
                writer.WriteAsync(text);
            }
        }

        public static bool FileReady(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    return false;
                }

                using (var input = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return input.Length > 0;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }

        public static class Scripts
        {
            private const string selfhostPath = "Scripts/selfhost.js";

            private static Lazy<string> selfhost = new Lazy<string>(() => ReadFileText(selfhostPath));

            public static string Selfhost => selfhost.Value;
        }
    }
}
