namespace MilkCanvas.Models
{
    using System;

    using Newtonsoft.Json;

    using TwitchLib.Events.Client;

    public class Command
    {
        [JsonProperty]
        private string identifier;

        [JsonProperty]
        private string description;

        [JsonProperty]
        private EventHandler<OnChatCommandReceivedArgs> callback;

        public Command(
            string identifier,
            string description,
            EventHandler<OnChatCommandReceivedArgs> callback)
        {
            this.identifier = identifier;
            this.description = description;
            this.callback = callback;
        }

        [JsonIgnore]
        public string Identifier => this.identifier;

        [JsonIgnore]
        public string Description => this.description;

        [JsonIgnore]
        public EventHandler<OnChatCommandReceivedArgs> Callback => this.callback;
    }
}
