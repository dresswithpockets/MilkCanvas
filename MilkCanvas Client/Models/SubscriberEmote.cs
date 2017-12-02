namespace MilkCanvas.Models
{
    using Newtonsoft.Json;

    public class SubscriberEmote
    {
#pragma warning disable CS0649
        [JsonProperty]
        private string id;

        [JsonProperty]
        private string code;

        [JsonProperty("emoticon_set")]
        private string emoteSet;
#pragma warning restore CS0649

        [JsonIgnore]
        public string ID => this.id;

        [JsonIgnore]
        public string Code => this.code;

        [JsonIgnore]
        public string EmoteSet => this.emoteSet;
    }
}
