using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace LUP.Parsing.Parsers
{
    public class StackMachineTable
    {
        private readonly ImmutableDictionary<(int, string), int> gotoTable;
        private readonly ImmutableDictionary<(int, string), StackMachineAction> actionTable;

        public IImmutableDictionary<(int, string), int> GotoTable => gotoTable;

        public IImmutableDictionary<(int, string), StackMachineAction> Actions => actionTable;

        public StackMachineTable(IDictionary<(int, string), int> gotoTable,
            IDictionary<(int, string), StackMachineAction> actionTable)
        {
            this.gotoTable = gotoTable.ToImmutableDictionary();
            this.actionTable = actionTable.ToImmutableDictionary();
        }

        
        public StackMachineTable()
        {
            gotoTable = ImmutableDictionary.Create<(int, string), int>();
            actionTable = ImmutableDictionary.Create<(int, string), StackMachineAction>();
        }



        public StackMachineAction GetAction(int state, string token)
        {
            if (actionTable.ContainsKey((state, token)) == false)
                return StackMachineAction.Error;

            return actionTable[(state, token)];
        }


        public int GetGoto(int state, string token)
        {
            if (gotoTable.ContainsKey((state, token)) == false)
                return -1;

            return gotoTable[(state, token)];
        }
    }
}
