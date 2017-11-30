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
        private const string commandsPath = "commands.json";
        private const string launchedKey = "Launched";
        private const string stateKey = "State";
        private const string twitchSubjectKey = "TwitchSubject";
        private const string twitchAccessTokenKey = "TwitchAccessToken";

        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

        private static readonly Lazy<Command[]> commands = new Lazy<Command[]>(() => JsonConvert.DeserializeObject<Command[]>(ReadFileText(commandsPath)));

        public static Command[] Commands => commands.Value;

        public static bool CommandsExist => File.Exists(commandsPath);

        public static bool FirstLaunch => GetSetting(launchedKey) == null;

        public static string State => GetSetting(stateKey)?.Value ?? null;

        public static string TwitchSubject => GetSetting(twitchSubjectKey)?.Value ?? null;

        public static string TwitchAccessToken => GetSetting(twitchAccessTokenKey)?.Value ?? null;

        public static KeyValueConfigurationElement GetSetting(string key) => config.AppSettings.Settings[key];

        public static void Save(bool? firstLaunch = null, string state = null, string twitchSubject = null, string twitchAccessToken = null)
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

            config.Save();
        }

        public static void SaveCommands(Command[] cmds)
        {
            SaveFileText(commandsPath, JsonConvert.SerializeObject(cmds));
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
            using (var file = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
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
