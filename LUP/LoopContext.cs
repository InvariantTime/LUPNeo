using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
    public class LoopContext
    {
        public CancellationToken Cancellation { get; }

        public LoopContext(CancellationToken token)
        {
            Cancellation = token;
        }
    }
}
