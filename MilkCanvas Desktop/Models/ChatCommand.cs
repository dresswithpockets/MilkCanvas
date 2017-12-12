namespace MilkCanvas.Models
{
    using Newtonsoft.Json;

    public class ChatCommand
    {
        [JsonProperty]
        private string identifier;

        [JsonProperty]
        private string message;

        public ChatCommand(string identifier, string message)
        {
            this.identifier = identifier;
            this.message = message;
        }

        [JsonIgnore]
        public string Identifier => this.identifier;

        [JsonIgnore]
        public string Message => this.message;
    }
}
