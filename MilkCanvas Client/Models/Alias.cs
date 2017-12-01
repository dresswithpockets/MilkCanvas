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
            this.Command = command;
            this.Alternate = alternate;
        }

        [JsonIgnore]
        public string Command { get; }

        [JsonIgnore]
        public string Alternate { get; }
    }
}
