using LUP.Parsing;
using System.Collections.Immutable;
using System.Text;

namespace LUP.Parsing.Parsers
{
    public class StackMachineTableGenerator
    {
        private readonly ImmutableArray<GrammarRule> rules;
        private readonly ImmutableArray<string> terminals;
        private readonly ImmutableArray<string> tokens;
        private readonly Dictionary<(LRSList, string), LRSList> gotos;
        private readonly string start;

        private int index;

        public StackMachineTableGenerator(Grammar grammar)
        {
            start = $"{grammar.FinalToken}'";
            rules = grammar.Rules.Add(new GrammarRule(start, new string[] { grammar.FinalToken }));
            tokens = grammar.Tokens.Add(start).Add(Lexer.End);
            terminals = grammar.Terminals.Add(Lexer.End);
            gotos = new();
        }


        public StackMachineTable Generate()
        {
            var items = GetItems();

            Dictionary<(int, string), StackMachineAction> actions = new();
            Dictionary<(int, string), int> gs = new();

            for (int i = 0; i < index; i++)
            {
                var list = items.First(x => x.Index == i);

                foreach (var a in tokens)
                {
                    if (GrammarFunctions.IsTerminal(a, terminals) == false)
                    {
                        gotos.TryGetValue((list, a), out var g);

                        if (g != null)
                            gs.Add((list.Index, a), g.Index);
                    }
                    else
                    {
                        var shift = list.FirstOrDefault(x => x.GetMark() == a);

                        var reduce = list.FirstOrDefault(x => x.Success == true && x.Chain == a
                                             && x.Rule.Result != start);
                        var accept = list.FirstOrDefault(x => x.Success == true &&
                                                x.Chain == Lexer.End && x.Rule.Result == start);

                        if (shift != null)
                        {
                            gotos.TryGetValue((list, a), out var g);

                            if (g != null)
                            {
                                actions.TryAdd((list.Index, a), new(g.Index));
                            }
                        }

                        if (reduce != null)
                        {
                            actions.TryAdd((list.Index, a), new(reduce.Rule));
                        }
                        else if (accept != null)
                        {
                            actions.TryAdd((list.Index, Lexer.End), StackMachineAction.Accept);
                        }
                    }
                }
            }

            return new StackMachineTable(gs, actions);
        }


        private void Close(LRSList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var s = list.ElementAt(i);

                if (s.Success == true)
                    continue;

                foreach (var rule in rules)
                {
                    if (rule.Result == s.GetMark())
                    {
                        IEnumerable<string> first;

                        if (s.Rule.Tokens.Length == s.Index + 1)
                        {
                            first = new string[] { s.Chain };
                        }
                        else
                        {
                            first = GrammarFunctions.First(s.Rule.Tokens[s.Index + 1], rules, terminals);
                        }

                        foreach (var f in first)
                        {
                            if (list.FirstOrDefault(x => x.Rule == rule 
                                && x.Index == 0 && x.Chain == f) != null)
                                continue;

                            list.Add(new LRSituation(rule, 0)
                            {
                                Chain = f
                            });
                        }
                    }
                }
            }
        }


        private LRSList? Goto(string token, LRSList list, IEnumerable<LRSList> lists)
        {
            List<LRSituation> situations = new();

            foreach (var s in list)
            {
                if (s.GetMark() == token)
                {
                    situations.Add(new LRSituation(s.Rule, s.Index + 1)
                    {
                        Chain = s.Chain
                    });
                }
            }

            if (situations.Count == 0)
                return null;


            var result = new LRSList(index, situations);
            Close(result);

            var old = lists.FirstOrDefault(x => x.Equals(result));

            if (old != null)
                return old;

            index++;
            return result;
        }


        private IEnumerable<LRSList> GetItems()
        {
            index = 1;
            gotos.Clear();

            LRSList start = new(0, new LRSituation(rules.Last(), 0));
            List<LRSList> lists = new()
            {
                start
            };

            Close(start);

            for (int i = 0; i < lists.Count; i++)
            {
                foreach (var token in tokens)
                {
                    var g = Goto(token, lists[i], lists);

                    if (g == null)
                        continue;

                    gotos.Add((lists[i], token), g);

                    if (lists.Contains(g) == false)
                        lists.Add(g);
                }
            }

            return lists;
        }
    }
}
