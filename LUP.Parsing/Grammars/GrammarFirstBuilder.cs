
namespace LUP.Parsing.Grammars
{
    public class GrammarFirstBuilder
    {
        private readonly Grammar grammar;

        public GrammarFirstBuilder(Grammar grammar)
        {
            this.grammar = grammar;
        }


        public IDictionary<string, IEnumerable<string>> Build()
        {
            var tokens = grammar.Tokens;

            return tokens.ToDictionary(x => x, BuildFor);
        }


        private IEnumerable<string> BuildFor(string token)
        {
            if (IsTerminal(token) == true)
                return new string[] { token };

            Stack<string> stack = new();
            int index = 0;

            stack.Push(token);

            HashSet<string> result = new();

            while (index < stack.Count)
            {
                token = stack.ElementAt(stack.Count - index - 1);
                index++;

                if (IsTerminal(token) == true)
                {
                    result.Add(token);
                    continue;
                }

                foreach (var rule in grammar.Rules)
                {
                    if (rule.Result == token)//B -> abc
                    {
                        if (rule.Tokens.Length == 0)
                        {
                            result.Add(string.Empty);
                            continue;
                        }

                        if (stack.Contains(rule.Tokens.First()) == false)
                            stack.Push(rule.Tokens.First());
                    }
                }
            }

            return result;
        }


        private bool IsTerminal(string token)
        {
            return grammar.Terminals.Contains(token);
        }
    }
}
