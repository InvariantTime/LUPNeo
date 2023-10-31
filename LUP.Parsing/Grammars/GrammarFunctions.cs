using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Parsers
{
    static class GrammarFunctions
    {

        public static IEnumerable<string> First(string token, ImmutableArray<GrammarRule> rules, 
            IEnumerable<string> terminals)
        {
            if (IsTerminal(token, terminals) == true)
                return new string[] { token };

            List<string> ts = new();

            for (int i = 0; i < rules.Length; i++)
            {
                if (rules[i].Result == token)
                {
                    if (rules[i].Tokens.Length == 0)
                        continue;

                    if (rules[i].Result == rules[i].Tokens.First())
                        continue;

                    ts.AddRange(First(rules[i].Tokens.First(), rules, terminals));
                }
            }

            return ts;
        }


        public static bool IsTerminal(string token, IEnumerable<string> terminals)
        {
            return terminals.Contains(token) == true;
        }
    }
}
