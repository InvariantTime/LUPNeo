using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.Parsers
{
    class StackMachineState
    {
        public GrammarRule Rule { get; }

        public StateTypes Type { get; }
        
        public StackMachineState(GrammarRule rule, StateTypes type)
        {
            Rule = rule;
            Type = type;
        }
    }

    enum StateTypes
    {
        Shift = 0,

        Reduce = 1,

        Success = 2
    }
}
