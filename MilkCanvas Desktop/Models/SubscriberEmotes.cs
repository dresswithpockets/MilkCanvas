namespace MilkCanvas.Models
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class SubscriberEmotes
    {
#pragma warning disable CS0649
        [JsonProperty("channel_name")]
        private string channelName;

        [JsonProperty("display_name")]
        private string displayName;

        [JsonProperty("channel_id")]
        private string channelId;

        [JsonProperty("broadcaster_type")]
        private string broadcasterType;

        [JsonProperty]
        private Dictionary<string, string> plans;

        [JsonProperty]
        private SubscriberEmote[] emotes;
#pragma warning restore CS0649

        [JsonIgnore]
        public string ChannelName => this.channelName;

        [JsonIgnore]
        public string DisplayName => this.displayName;

        [JsonIgnore]
        public string ChannelID => this.channelId;

        [JsonIgnore]
        public string BroadcasterType => this.broadcasterType;

        [JsonIgnore]
        public Dictionary<string, string> Plans => this.plans;

        [JsonIgnore]
        public SubscriberEmote[] Emotes => this.emotes;
    }
}
