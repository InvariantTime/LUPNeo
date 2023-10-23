using System.Collections.Immutable;

namespace LUP.Rendering.ShaderLanguage.Parsers
{
    class StackMachineTableGenerator
    {
        private static readonly string startToken = "S";

        private readonly Grammar grammar;
        private readonly Dictionary<(int, string), StackJump> jumps;

        public StackMachineTableGenerator(Grammar grammar)
        {
            this.grammar = grammar;
            jumps = new();
        }

        public StackMachineTable Generate()
        {
            var start = new State(new StateRule(startToken, ImmutableArray.Create(grammar.FinalToken), 0), 0);

            Close(start);

            List<State> states = new()
            {
                start
            };

            for (int i = 0; i < states.Count; i++)
            {
                AddReducing(states[i]);

                foreach (var terminal in grammar.Tokens)
                {
                    var @new = ShiftState(states[i], terminal);

                    if (@new != null)
                    {
                        @new.Index = states.Count;
                        states.Add(@new);
                        AddOrUpdate(states[i].Index, terminal, new StackJump(@new.Index, StateTypes.Shift));
                    }
                }
            }

            return new StackMachineTable(jumps.ToImmutableDictionary(), start.Index);
        }


        private void Close(State state)
        {
            for (int i = 0; i < state.Rules.Count; i++)
            {
                var rule = state.Rules.ElementAt(i);

                if (rule.Tokens.Contains(rule.Result) == true)
                    continue;

                if (rule.Success == false && grammar.IsNonTerminal(rule.Tokens[rule.Index]) == true)
                {
                    for (int j = 0; j < grammar.Rules.Length; j++)
                    {
                        if (grammar.Rules[j].Result == rule.Tokens[rule.Index])
                        {
                            state.Rules.Add(new StateRule(grammar.Rules[j].Result, grammar.Rules[j].Tokens, 0));
                        }
                    }
                }
            }
        }


        private State? ShiftState(State old, string token)
        {
            State state = new(0);

            for (int i = 0; i < old.Rules.Count; i++)
            {
                var rule = old.Rules[i];

                if (rule.Success == false && rule.Tokens[rule.Index] == token)
                {
                    var @new = new StateRule(rule.Result, rule.Tokens, rule.Index + 1);
                    state.Rules.Add(@new);
                }
            }

            if (state.Rules.Count == 0)
                return null;

            Close(state);
            return state;
        }


        private void AddReducing(State state)
        {
            foreach (var rule in state.Rules)
            {
                if (rule.Success == true)
                {
                    if (rule.Result == startToken)
                    {
                        AddOrUpdate(state.Index, ShaderLexer.End, new(state.Index, StateTypes.Success));
                    }
                    else
                    {
                        foreach (var term in Next(rule.Result))
                        {
                            AddOrUpdate(state.Index, term, new StackJump
                            {
                                NewState = state.Index,
                                Type = StateTypes.Reduce,
                                Rule = new GrammarRule(rule.Result, rule.Tokens)
                            });
                        }
                    }
                }
            }
        }


        private IEnumerable<string> Next(string token)
        {
            List<string> tokens = new();

            foreach (var rule in grammar.Rules)
            {
                if (rule.Tokens.Last() == token)
                {
                    tokens.AddRange(Next(rule.Result));
                }
                else if (rule.Tokens.Contains(token) == true)
                {
                    int i = rule.Tokens.IndexOf(token);
                    tokens.AddRange(First(rule.Tokens[i + 1]));
                }
            }

            return tokens;
        }


        private IEnumerable<string> First(string token)
        {
            List<string> tokens = new();

            if (grammar.IsNonTerminal(token) == false)
            {
                tokens.Add(token);
                return tokens;
            }

            foreach (var rule in grammar.Rules)
            {
                if (rule.Result == token)
                {
                    tokens.AddRange(First(rule.Tokens[0]));
                }
            }

            return tokens;
        }


        private void AddOrUpdate(int index, string token, StackJump jump)
        {
            var key = (index, token);

            if (jumps.ContainsKey(key) == true)
            {
                StackJump mix = new()
                {
                    NewState = jumps[key].NewState,
                    Type = jump.Type,
                    Rule = jump.Rule
                };

                jumps[key] = mix;
                return;
            }

            jumps.Add(key, jump);
        }


        private class State
        {
            public List<StateRule> Rules { get; }

            public int Index { get; set; }

            public State(StateRule rule, int index)
            {
                Rules = new()
                {
                    rule
                };

                Index = index;
            }


            public State(int index)
            {
                Rules = new();
                Index = index;
            }
        }

        private class StateRule
        {
            public int Index { get; }

            public string Result { get; }

            public ImmutableArray<string> Tokens { get; }

            public bool Success => Index == Tokens.Length;

            public StateRule(string result, ImmutableArray<string> tokens, int index)
            {
                Index = index;
                Result = result;
                Tokens = tokens;
            }
        }
    }
}
