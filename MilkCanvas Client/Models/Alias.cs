namespace MilkCanvas.Models
{
    using Newtonsoft.Json;

    public class Alias
    {
        [JsonProperty]
        private string command;

        [JsonProperty]
        private string alternate;

        public Alias(string command, string alternate)
        {
            this.command = command;
            this.alternate = alternate;
        }

        [JsonIgnore]
        public string Command => this.command;

        [JsonIgnore]
        public string Alternate => this.alternate;
    }
}
