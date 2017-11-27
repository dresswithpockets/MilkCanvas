using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkCanvas_Client
{
    public class TwitchAuthenticatedEventArgs : EventArgs
    {
        public TwitchHashFile Hash { get; }
        public TwitchAuthenticatedEventArgs(TwitchHashFile hash)
        {
            Hash = hash;
        }
    }
}
