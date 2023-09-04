using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection.CallSites
{
    public class InstanceCallsite : Callsite
    {
        public required Type Implementation { get; init; }

        public required LifeTimes LifeTime { get; init; }

        public Func<IServiceScope, object>? Func { get; init; }

        public object? Value { get; set; }
    }
}
