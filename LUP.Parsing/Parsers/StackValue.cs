using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Parsers
{
    readonly struct StackValue
    {
        public int State { get; }

        public KeyToken Token { get; }

        public StackValueTypes Type { get; }

        public StackValue(KeyToken token)
        {
            Token = token;
            Type = StackValueTypes.Token;
        }


        public StackValue(int state)
        {
            State = state;
            Type = StackValueTypes.State;
        }
    }


    enum StackValueTypes
    {
        State,

        Token,
    }


    public readonly struct KeyToken
    {
        public int Key { get; init; }

        public Token Token { get; init; }

        public bool IsTerminal { get; }

        public KeyToken(Token token, int key, bool isTerminal = false)
        {
            Token = token;
            Key = key;
            IsTerminal = isTerminal;
        }


        public override bool Equals(object? obj)
        {
            return obj is KeyToken token &&
                   Key == token.Key &&
                   EqualityComparer<Token>.Default.Equals(Token, token.Token);
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Key, Token);
        }
    }
}
