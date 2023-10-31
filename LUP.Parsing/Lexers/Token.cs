using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LUP.Parsing
{
    public readonly struct Token
    {
        public static readonly Token Empty = new()
        {
            Type = "EOF"
        };

        public string Type { get; init; }

        public string? Value { get; init; }
    }
}
