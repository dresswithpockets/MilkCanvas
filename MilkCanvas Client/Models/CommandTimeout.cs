namespace MilkCanvas.Models
{
    using System.Timers;

    public class CommandTimeout
    {
        public CommandTimeout(string command, Timer timer)
        {
            this.Command = command;
            this.Timer = timer;
        }

        public string Command { get; }

        public Timer Timer { get; }
    }
}
