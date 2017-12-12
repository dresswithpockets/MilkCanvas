namespace MilkCanvas
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using TwitchLib;

    public static class Utility
    {

        public static string Get(string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static string GetDisplayNameFromID(TwitchAPI api, string userid)
        {
            return api.Users.v5.GetUserByIDAsync(userid).GetAwaiter().GetResult().DisplayName;
        }

        public static async Task<string> GetUserIDAsync(this TwitchAPI api, string username)
        {
            var user = await api.Users.v5.GetUserByNameAsync(username);
            return user.Matches[0].Id;
        }

        public static async Task<TimeSpan?> GetUptimeAsync(this TwitchAPI api, string channelId)
        {
            if (await api.Streams.v5.BroadcasterOnlineAsync(channelId))
            {
                return await api.Streams.v5.GetUptimeAsync(channelId);
            }
            else
            {
                return null;
            }
        }
    }
}
