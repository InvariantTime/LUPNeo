using LUP.Parsing.Grammars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Parsers
{
    public static class StackTableReader
    {
        public static StackMachineTable Read(Stream stream)
        {
            using BinaryReader reader = new(stream);
            int actionCount = reader.ReadInt32();

            var actions = new Dictionary<(int, string), StackMachineAction>();
            var gotos = new Dictionary<(int, string), int>();

            for (int i = 0; i < actionCount; i++)
            {
                int s = reader.ReadInt32();
                string t = reader.ReadString();

                MachineActionTypes type = (MachineActionTypes)reader.ReadInt32();

                switch (type)
                {
                    case MachineActionTypes.Shift:
                        int state = reader.ReadInt32();
                        actions.Add((s, t), new(state));
                        break;

                    case MachineActionTypes.Reduce:
                        var rule = ReadRule(reader);
                        actions.Add((s, t), new(rule));
                        break;

                    case MachineActionTypes.Accept:
                        actions.Add((s, t), StackMachineAction.Accept);
                        break;

                    default: throw new NotSupportedException();
                }
            }

            int gotoCount = reader.ReadInt32();

            for (int i = 0; i < gotoCount; i++)
            {
                int s = reader.ReadInt32();
                string t = reader.ReadString();
                int g = reader.ReadInt32();

                gotos.Add((s, t), g);
            }

            return new StackMachineTable(gotos, actions);
        }


        public static void Write(StackMachineTable table, Stream stream)
        {
            using BinaryWriter writer = new(stream);

            writer.Write(table.Actions.Count);

            foreach (var action in table.Actions)
            {
                writer.Write(action.Key.Item1);
                writer.Write(action.Key.Item2);

                writer.Write(Convert.ToInt32(action.Value.Type));
                
                if (action.Value.Type == MachineActionTypes.Shift)
                {
                    writer.Write(action.Value.State);
                }
                else if(action.Value.Type == MachineActionTypes.Reduce)
                {
                    WriteRule(action.Value.Rule, writer);
                }
            }

            writer.Write(table.GotoTable.Count);

            foreach (var @goto in table.GotoTable)
            {
                writer.Write(@goto.Key.Item1);
                writer.Write(@goto.Key.Item2);
                writer.Write(@goto.Value);
            }
        }


        public static StackMachineTable Read(byte[] bytes)
        {
            using MemoryStream stream = new(bytes, false);
            return Read(stream);
        }


        private static void WriteRule(GrammarRule? rule, BinaryWriter writer)
        {
            if (rule == null)
                throw new ArgumentNullException(nameof(rule));

            writer.Write(rule.Result);
            writer.Write(rule.Tokens.Length);

            foreach (var token in rule.Tokens)
            {
                writer.Write(token);
            }

            writer.Write(rule.Param != null);

            if (rule.Param != null)
            {
                writer.Write(rule.Param.Name);
                writer.Write(rule.Param.TokenIndices.Length);

                foreach (var index in rule.Param.TokenIndices)
                    writer.Write(index);
            }
        }


        private static GrammarRule ReadRule(BinaryReader reader)
        {
            var result = reader.ReadString();
            int count = reader.ReadInt32();

            string[] tokens = new string[count];

            for (int i = 0; i < count; i++)
                tokens[i] = reader.ReadString();

            var rule = new GrammarRule(result, tokens);

            bool hasParam = reader.ReadBoolean();

            if (hasParam == true)
            {
                string name = reader.ReadString();
                int indexCount = reader.ReadInt32();
                int[] indices = new int[indexCount];

                for (int i = 0; i < indexCount; i++)
                    indices[i] = reader.ReadInt32();

                ReduceParam param = new(name, indices);
                rule.SetParam(param);   
            }

            return rule;
        }
    }
}
