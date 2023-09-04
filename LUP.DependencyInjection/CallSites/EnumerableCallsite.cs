using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection.CallSites
{
    public class EnumerableCallsite : Callsite
    {
        public required Type GenericAlias { get; init; }

        public required Callsite[] Callsites { get; init; }
    }
}
