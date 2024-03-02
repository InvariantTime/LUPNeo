using LUP.Rendering.Language.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Members
{
    public class ShaderMethod : IShaderMember
    {
        public bool IsOverrided { get; }

        public string Alias { get; }

        public IShaderStatement Body { get; }
    }
}