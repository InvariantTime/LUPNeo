using System.Collections;

namespace LUP.Parsing.Parsers
{
    class LRSList : IEnumerable<LRSituation>
    {
        private readonly List<LRSituation> situations;

        public int Index { get; }

        public int Count => situations.Count;

        public LRSList(int index, LRSituation situation)
        {
            Index = index;
            situations = new()
            {
                situation
            };
        }

        public LRSList(int index, IEnumerable<LRSituation> situations)
        {
            Index = index;
            this.situations = new(situations);
        }


        public void Add(LRSituation situation)
        {
            situations.Add(situation);
        }


        public IEnumerator<LRSituation> GetEnumerator()
        {
            return situations.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return situations.GetEnumerator();
        }


        public override string ToString()
        {
            return Index.ToString();
        }


        public override bool Equals(object? obj)
        {
            if (obj is LRSList list)
            {
                return Equals(list, Count);
            }

            return false;
        }


        public bool Equals(IEnumerable<LRSituation> situations, int count)
        {
            if (count != Count)
                return false;

            foreach (var situation in situations)
            {
                if (this.FirstOrDefault(x => x.Equals(situation) == true) == null)
                    return false;
            }

            foreach (var situation in this)
            {
                if (situations.FirstOrDefault(x => x.Equals(situation) == true) == null)
                    return false;
            }

            return true;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(situations);
        }
    }


    class LRSituation
    {
        public int Index { get; }

        public GrammarRule Rule { get; }

        public string Chain { get; set; } = Lexer.End;

        public bool Success => Index >= Rule.Tokens.Length;

        public LRSituation(GrammarRule rule, int index)
        {
            Rule = rule;
            Index = index;
        }


        public string GetMark()
        {
            if (Success == true)
                return string.Empty;

            return Rule.Tokens[Index];
        }


        public string GetNext()
        {
            if (Success == true)
                return string.Empty;//A = 1 * B C = * B

            return Rule.Tokens[Index + 1];
        }


        public override bool Equals(object? obj)
        {
            return obj is LRSituation situation &&
                   Index == situation.Index &&
                   Rule == situation.Rule &&
                   Chain == situation.Chain;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Index, Rule, Chain);
        }
    }
}
