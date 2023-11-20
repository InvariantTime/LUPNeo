using LUP.Parsing.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST.Expressions
{
    public readonly struct ReduceContext
    {
        public ReduceRegister Register { get; init; }

        public ReducePool Pool { get; init; }

        public KeyToken ResultToken { get; init; }

        public KeyToken[] Tokens { get; init; }
    }
}
