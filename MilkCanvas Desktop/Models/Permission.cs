namespace MilkCanvas.Models
{
    using Enums;

    using Newtonsoft.Json;

    public class Permission
    {
        [JsonProperty]
        private string command;

        [JsonProperty]
        private UserGroup group;

        public Permission(string command, UserGroup group)
        {
            this.command = command;
            this.group = group;
        }

        [JsonIgnore]
        public string Command => this.command;

        [JsonIgnore]
        public UserGroup Group => this.group;
    }
}
