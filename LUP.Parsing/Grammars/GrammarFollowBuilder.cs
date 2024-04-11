
namespace LUP.Parsing.Grammars
{
    public class GrammarFollowBuilder
    {
        private static readonly string[] empty = { Lexer.End };

        private readonly IDictionary<string, IEnumerable<string>> firstList;
        private readonly Grammar grammar;

        public GrammarFollowBuilder(IDictionary<string, IEnumerable<string>> firstList, Grammar grammar)
        {
            this.firstList = firstList;
            this.grammar = grammar;
        }


        public IDictionary<string, IEnumerable<string>> Build()
        {
            var nonTerminals = grammar.NonTerminals;
            return nonTerminals.ToDictionary(x => x, GetFollowFor);
        }


        private IEnumerable<string> GetFollowFor(string token)
        {
            if (token == grammar.FinalToken)
                return empty;

            Stack<string> stack = new();
            stack.Push(token);

            HashSet<string> result = new();

            int index = 0;

            while (stack.Count > index)
            {
                token = stack.ElementAt(stack.Count - index - 1);
                index++;

                if (token == grammar.FinalToken)
                {
                    result.Add(Lexer.End);
                    continue;
                }

                foreach (var rule in grammar.Rules)
                {
                    bool needWrite = false;

                    for (int i = 0; i < rule.Tokens.Length; i++)
                    {
                        var current = rule.Tokens[i];

                        if (current == token)
                            needWrite = true;

                        if (needWrite == true)
                        {
                            if (i == rule.Tokens.Length - 1)//A -> aB
                            {
                                if (stack.Contains(rule.Result) == false)
                                    stack.Push(rule.Result);

                                needWrite = false;
                            }
                            else//A -> aBcd
                            {
                                var firsts = firstList[rule.Tokens[i + 1]];
                                needWrite = firsts.Contains(string.Empty);

                                foreach (var f in firsts)
                                {
                                    if (f == string.Empty)
                                        continue;

                                    result.Add(f);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
