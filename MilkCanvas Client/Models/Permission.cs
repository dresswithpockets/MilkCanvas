namespace MilkCanvas.Models
{
    using Enums;

    using Newtonsoft.Json;

    public class Permission
    {
        [JsonProperty]
        private string command;

        [JsonProperty]
        private Group group;

        public Permission(string command, Group group)
        {
            this.command = command;
            this.group = group;
        }

        [JsonIgnore]
        public string Command => command;

        [JsonIgnore]
        public Group Group => group;
    }
}
