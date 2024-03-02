using LUP.Rendering.Language.Members;
using System.Collections.Immutable;

namespace LUP.Rendering.Language
{
    public class ShaderClass
    {
        public ImmutableArray<IShaderMember> Members { get; }

        public ShaderMethodTable Methods { get; }

        public ShaderClassType Type { get; }

        internal ShaderClass(IEnumerable<IShaderMember> members, ShaderMethodTable table, ShaderClassType type)
        {
            Members = members.ToImmutableArray();
            Type = type;
            Methods = table;
        }

        
        public void CreateShaderInstance(params ShaderParamValue[] parameters)
        {
           // var classParams = this.GetClassParamters();
        }


        public static ShaderClass Create(ShaderClassDescriptor descriptor)
        {
            return ShaderClassGenerator.Generate(descriptor);
        }
    }
}
