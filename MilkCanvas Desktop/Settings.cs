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
        private const int bookmarkFilenameLength = 64;
        private const string bookmarksPath = "./bookmarks";
        private const string chatCommandsPath = "commands.json";
        private const string permissionsPath = "permissions.json";
        private const string aliasesPath = "aliases.json";
        private const string emotesPath = "emotes.json";

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

        private const string tagUsersKey = "TagUsers";
        private const string modsCanPseudoTagKey = "ModsCanPseudoTag";

        private const string exemptModsFromDelayKey = "ExemptModsFromDelay";
        private const string modsSetChatCommandsKey = "ModsSetChatCommands";
        private const string modsRemoveChatCommandsKey = "ModsRemoveChatCommands";
        private const string modsSetAliasesKey = "ModsSetAliases";
        private const string modsRemoveAliasesKey = "ModsRemoveAliases";

        private const string useBookmarkHotkeyKey = "UseBookmarkHotkey";
        private const string bookmarkModifiersKey = "BookmarkModifiers";
        private const string bookmarkHotkeyKey = "BookmarkHotkey";

        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

        private static readonly Lazy<ChatCommand[]> chatCommands = new Lazy<ChatCommand[]>(() => JsonConvert.DeserializeObject<ChatCommand[]>(ReadFileText(chatCommandsPath), new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
        private static readonly Lazy<Permission[]> permissions = new Lazy<Permission[]>(() => JsonConvert.DeserializeObject<Permission[]>(ReadFileText(permissionsPath)));
        private static readonly Lazy<Alias[]> aliases = new Lazy<Alias[]>(() => JsonConvert.DeserializeObject<Alias[]>(ReadFileText(aliasesPath)));
        private static readonly Lazy<string[]> emotes = new Lazy<string[]>(() => JsonConvert.DeserializeObject<string[]>(ReadFileText(emotesPath)));

        public static ChatCommand[] ChatCommands => chatCommands.Value;

        public static Permission[] Permissions => permissions.Value;

        public static Alias[] Aliases => aliases.Value;

        public static string[] Emotes => emotes.Value;

        public static bool ChatCommandsExist => File.Exists(chatCommandsPath);

        public static bool PermissionsExist => File.Exists(permissionsPath);

        public static bool AliasesExists => File.Exists(aliasesPath);

        public static bool EmotesExists => File.Exists(emotesPath);

        public static bool FirstLaunch => GetSetting(launchedKey) == null;

        public static string State => GetString(stateKey);

        public static string TwitchSubject => GetString(twitchSubjectKey);

        public static string TwitchAccessToken => GetString(twitchAccessTokenKey);

        public static bool UseAlternateAccount => GetBool(useAlternateAccountKey);

        public static string AltTwitchSubject => GetString(altTwitchSubjectKey);

        public static string AltTwitchAccessToken => GetString(altTwitchAccessTokenKey);

        public static bool UseSubMessage => GetBool(useSubMessageKey);

        public static string SubMessage => GetString(subMessageKey);

        public static bool UseResubMessage => GetBool(useResubMessageKey);

        public static string ResubMessage => GetString(resubMessageKey);

        public static bool UseGiftedSubMessage => GetBool(useGiftedSubMessageKey);

        public static string GiftedSubMessage => GetString(giftedSubMessageKey);

        public static bool UseCommandDelay => GetBool(useCommandDelayKey);

        public static int CommandDelay => GetInt(commandDelayKey);

        public static bool ReconnectCanvas => GetBool(reconnectCanvasKey);

        public static int ReconnectDelay => GetInt(reconnectDelayKey);

        public static bool TagUsers => GetBool(tagUsersKey);

        public static bool ModsCanPseudoTag => GetBool(modsCanPseudoTagKey);

        public static bool ExemptModsFromDelay => GetBool(exemptModsFromDelayKey);

        public static bool ModsSetChatCommands => GetBool(modsSetChatCommandsKey);

        public static bool ModsRemoveChatCommands => GetBool(modsRemoveChatCommandsKey);

        public static bool ModsSetAliases => GetBool(modsSetAliasesKey);

        public static bool ModsRemoveAliases => GetBool(modsRemoveAliasesKey);

        public static bool UseBookmarkHotkey => GetBool(useBookmarkHotkeyKey);

        public static int BookmarkModifiers => GetInt(bookmarkModifiersKey);

        public static int BookmarkHotkey => GetInt(bookmarkHotkeyKey);

        public static KeyValueConfigurationElement GetSetting(string key) => config.AppSettings.Settings[key];

        public static bool GetBool(string key)
        {
            var setting = GetSetting(key);
            if (setting != null)
            {
                return bool.TrueString.Equals(setting.Value);
            }

            return false;
        }

        public static string GetString(string key)
        {
            var setting = GetSetting(key);
            if (setting != null)
            {
                return setting.Value;
            }

            return null;
        }

        public static int GetInt(string key)
        {
            var setting = GetSetting(key);
            if (setting != null && int.TryParse(setting.Value, out var value))
            {
                return value;
            }

            return 0;
        }

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
            bool? tagUsers = null,
            bool? modsCanPseudoTag = null,
            bool? exemptModsFromDelay = null,
            bool? modsSetChatCommands = null,
            bool? modsRemoveChatCommands = null,
            bool? modsSetAliases = null,
            bool? modsRemoveAliases = null,
            bool? useBookmarkHotkey = null,
            int? bookmarkModifiers = null,
            int? bookmarkHotkey = null)
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

            // tagging options
            if (tagUsers != null)
            {
                UpdateSetting(tagUsersKey, tagUsers.Value.ToString());
            }

            if (modsCanPseudoTag != null)
            {
                UpdateSetting(modsCanPseudoTagKey, modsCanPseudoTag.Value.ToString());
            }

            // permissions
            if (exemptModsFromDelay != null)
            {
                UpdateSetting(exemptModsFromDelayKey, exemptModsFromDelay.Value.ToString());
            }

            if (modsSetChatCommands != null)
            {
                UpdateSetting(modsSetChatCommandsKey, modsSetChatCommands.Value.ToString());
            }

            if (modsRemoveChatCommands != null)
            {
                UpdateSetting(modsRemoveChatCommandsKey, modsRemoveChatCommands.Value.ToString());
            }

            if (modsSetAliases != null)
            {
                UpdateSetting(modsSetAliasesKey, modsSetAliases.Value.ToString());
            }

            if (modsRemoveAliases != null)
            {
                UpdateSetting(modsRemoveAliasesKey, modsRemoveAliases.Value.ToString());
            }

            // bookmarks
            if (useBookmarkHotkey != null)
            {
                UpdateSetting(useBookmarkHotkeyKey, useBookmarkHotkey.Value.ToString());
            }

            if (bookmarkModifiers != null)
            {
                UpdateSetting(bookmarkModifiersKey, bookmarkModifiers.Value.ToString());
            }

            if (bookmarkHotkey != null)
            {
                UpdateSetting(bookmarkHotkeyKey, bookmarkHotkey.Value.ToString());
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

        public static void SaveEmotes(List<string> emotes)
        {
            SaveFileText(emotesPath, JsonConvert.SerializeObject(emotes));
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

        public static void SaveFileText(string path, string text, bool block = false)
        {
            // if we want to block, then block until the file is ready to be opened.
            if (block)
            {
                while (!FileReady(path))
                {
                }
            }

            using (var file = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(file))
            {
                writer.Write(text);
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
