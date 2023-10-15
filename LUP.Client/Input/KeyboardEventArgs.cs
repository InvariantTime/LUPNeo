using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client.Input
{
    public sealed class KeyboardEventArgs : EventArgs
    {
        public KeyboardKeys Key { get; init; }
    }
}
