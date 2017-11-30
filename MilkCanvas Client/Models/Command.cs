namespace MilkCanvas.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TwitchLib.Events.Client;
    using TwitchLib.Models.Client;

    public class Command
    {
        public Command(
            string identifier,
            string description,
            EventHandler<OnChatCommandReceivedArgs> chatCommand,
            EventHandler<OnWhisperCommandReceivedArgs> whisperCommand = null)
        {
            this.Identifier = identifier;
            this.Description = description;
            this.ChatCommandReceived = chatCommand;
            this.WhisperCommandReceived = whisperCommand;
        }

        public string Identifier { get; }

        public string Description { get; }

        public EventHandler<OnChatCommandReceivedArgs> ChatCommandReceived { get; }

        public EventHandler<OnWhisperCommandReceivedArgs> WhisperCommandReceived { get; }
    }
}
