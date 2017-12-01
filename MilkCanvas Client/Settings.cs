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

        private const string subMessageKey = "SubMessage";
        private const string resubMessageKey = "ResubMessage";
        private const string giftedSubMessageKey = "GiftedSubMessage";
        private const string commandDelayKey = "CommandDelay";

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

        public static string State => GetSetting(stateKey)?.Value;

        public static string TwitchSubject => GetSetting(twitchSubjectKey)?.Value;

        public static string TwitchAccessToken => GetSetting(twitchAccessTokenKey)?.Value;

        public static string SubMessage => GetSetting(subMessageKey)?.Value;

        public static string ResubMessage => GetSetting(resubMessageKey)?.Value;

        public static string GiftedSubMessage => GetSetting(giftedSubMessageKey)?.Value;

        public static float CommandDelay => float.Parse(GetSetting(commandDelayKey)?.Value ?? "0");

        public static bool ExemptModsFromDelay => bool.TrueString.Equals(GetSetting(exemptModsFromDelayKey)?.Value);

        public static bool ModsSetChatCommands => bool.TrueString.Equals(GetSetting(modsSetChatCommandsKey)?.Value);

        public static bool ModsRemoveChatCommands => bool.TrueString.Equals(GetSetting(modsRemoveChatCommandsKey)?.Value);

        public static bool ModsSetAliases => bool.TrueString.Equals(GetSetting(modsSetAliasesKey)?.Value);

        public static bool ModsRemoveAliases => bool.TrueString.Equals(GetSetting(modsRemoveAliasesKey)?.Value);

        public static KeyValueConfigurationElement GetSetting(string key) => config.AppSettings.Settings[key];

        public static void Save(
            bool? firstLaunch = null,
            string state = null,
            string twitchSubject = null,
            string twitchAccessToken = null,
            string subMessage = null,
            string resubMessage = null,
            string giftedSubMessage = null,
            float? commandDelay = null,
            bool? exemptModsFromDelay = null,
            bool? modsSetChatCommands = null,
            bool? modsRemoveChatCommands = null,
            bool? modsSetAliases = null,
            bool? modsRemoveAliases = null)
        {
            if (firstLaunch.HasValue)
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

            if (commandDelay != null)
            {
                UpdateSetting(commandDelayKey, commandDelay.Value.ToString());
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
