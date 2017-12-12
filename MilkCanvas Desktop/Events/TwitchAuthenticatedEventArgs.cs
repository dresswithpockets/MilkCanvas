namespace MilkCanvas.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MilkCanvas.Models;

    public class TwitchAuthenticatedEventArgs : EventArgs
    {
        public TwitchAuthenticatedEventArgs(TwitchHashFile hash)
        {
            this.Hash = hash;
        }

        public TwitchHashFile Hash { get; }
    }
}
