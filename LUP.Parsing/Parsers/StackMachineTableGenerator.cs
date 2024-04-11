using LUP.Parsing.Grammars;

namespace LUP.Parsing.Parsers
{
    public class StackMachineTableGenerator
    {
        private readonly Dictionary<(LRSList, string), LRSList> gotos;
        private readonly IDictionary<string, IEnumerable<string>> firstList;
        private readonly IDictionary<string, IEnumerable<string>> followList;
        private readonly Grammar grammar;

        private int index;

        private StackMachineTableGenerator(Grammar grammar,
            IDictionary<string, IEnumerable<string>> firstList, 
            IDictionary<string, IEnumerable<string>> followList)
        {
            this.grammar = grammar;
            this.firstList = firstList;
            this.followList = followList;

            gotos = new();
        }


        public static StackMachineTableGenerator Create(Grammar grammar)
        {
            var start = $"{grammar.FinalToken}'";
            var rules = grammar.Rules.Add(new GrammarRule(start, new string[] { grammar.FinalToken }));
            var tokens = grammar.Tokens.Add(start).Add(Lexer.End);

            var newGrammar = new Grammar(rules, tokens, start);
            var firstList = new GrammarFirstBuilder(newGrammar).Build();
            var followList = new GrammarFollowBuilder(firstList, newGrammar).Build();

            return new StackMachineTableGenerator(newGrammar, firstList, followList);
        }


        public StackMachineTable Generate()
        {
            var items = GetItems();

            Dictionary<(int, string), StackMachineAction> actions = new();
            Dictionary<(int, string), int> gs = new();

            for (int i = 0; i < index; i++)
            {
                var list = items.First(x => x.Index == i);

                foreach (var a in grammar.Tokens)
                {
                    if (grammar.IsNonTerminal(a) == true)
                    {
                        gotos.TryGetValue((list, a), out var g);

                        if (g != null)
                            gs.Add((list.Index, a), g.Index);
                    }
                    else
                    {
                        var shift = list.FirstOrDefault(x => x.GetMark() == a);

                        var reduce = list.FirstOrDefault(x => x.Success == true && x.Chain == a
                                             && x.Rule.Result != grammar.FinalToken);
                        var accept = list.FirstOrDefault(x => x.Success == true &&
                                                x.Chain == Lexer.End && x.Rule.Result == grammar.FinalToken);

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

                foreach (var rule in grammar.Rules)
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
                            firstList.TryGetValue(s.Rule.Tokens[s.Index + 1], out var result);
                            first = result ?? Enumerable.Empty<string>();
                        }

                        AddSituations(list, rule, first);
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

            LRSList start = new(0, new LRSituation(grammar.Rules.Last(), 0));
            List<LRSList> lists = new()
            {
                start
            };

            Close(start);

            for (int i = 0; i < lists.Count; i++)
            {
                foreach (var token in grammar.Tokens)
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


        private void AddSituations(LRSList list, GrammarRule rule, IEnumerable<string> firsts)
        {
            foreach (var f in firsts)
            {
                if (f == string.Empty)
                {
                    followList.TryGetValue(rule.Result, out var follows);

                    if (follows != null)
                        AddSituations(list, rule, follows);

                    return;
                }

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
