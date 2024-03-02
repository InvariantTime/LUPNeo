using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Members
{
    public record ShaderAttribute
    {
        public bool Output { get; }

        public int Index { get; }

        public string Alias { get; }
    }
}
