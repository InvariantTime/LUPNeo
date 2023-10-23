using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.Parsers
{
    class StackMachineTable
    {
        private readonly ImmutableDictionary<(int, string), StackJump> jumps;

        public int Start { get; }

        public StackMachineTable(ImmutableDictionary<(int, string), StackJump> jumps, int start)
        {
            this.jumps = jumps;
            Start = start;
        }


        public bool TryGetState(int state, string input, out StackJump jmp)
        {
            return jumps.TryGetValue((state, input), out jmp);
        }
    }

    readonly struct StackJump
    {
        public int NewState { get; init; }

        public StateTypes Type { get; init; }

        public GrammarRule? Rule { get; init; }

        public StackJump(int newState, StateTypes type)
        {
            NewState = newState;
            Type = type;
        }
    }
}
