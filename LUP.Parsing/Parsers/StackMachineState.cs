using LUP.Parsing;

namespace LUP.Parsing.Parsers
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
