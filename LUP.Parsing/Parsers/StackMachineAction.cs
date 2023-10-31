using LUP.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LUP.Parsing.Parsers
{
    public readonly struct StackMachineAction
    {
        public static readonly StackMachineAction Error = new(MachineActionTypes.Error);

        public static readonly StackMachineAction Accept = new(MachineActionTypes.Accept);

        public MachineActionTypes Type { get; }

        public int State { get; }

        public GrammarRule? Rule { get; }

        public StackMachineAction(int state)
        {
            Type = MachineActionTypes.Shift;
            State = state;
        }


        public StackMachineAction(GrammarRule rule)
        {
            Rule = rule;
            Type = MachineActionTypes.Reduce;
        }


        public StackMachineAction(MachineActionTypes type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return Type switch
            {
                MachineActionTypes.Shift => $"{Type} {State}",

                _ => $"{Type}"
            };
        }
    }

    [Serializable]
    public enum MachineActionTypes
    {
        Error = default,

        Shift,

        Reduce,

        Accept
    }
}
