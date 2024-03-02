using LUP.Graphics.Enums;
using LUP.Graphics.Resources;
using LUP.Rendering.Language.Expressions;
using LUP.Rendering.Language.Objects;

namespace LUP.Rendering.Language.Generation
{
    public class ShaderGenerator
    {
        private readonly ShaderCodeGenerator codeGenerator;

        public ShaderGenerator(IShaderGenerationProvider provider)
        {
            codeGenerator = new(provider);
        }

        
        public ShaderDescriptor Compile(ShaderSource source)
        {
            ShaderPart[] parts = new ShaderPart[source.Classes.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                var main = GetMainMethod(source.Classes[i]) ??
                    throw new InvalidOperationException("Shader source class must have one of main methods");

                if (parts.FirstOrDefault(x => x.Type == main.Item1).Source != null)
                    throw new InvalidOperationException("Shader source cannot have two identical classes");

                var members = HandleMembers(source);

                var descriptor = new ShaderCodeDescriptor
                {
                    Class = source.Classes[i],
                    Main = main.Item2,
                    Type = main.Item1
                };

                parts[i] = new(main.Item1, codeGenerator.Generate(descriptor, source));
            }

            return new ShaderDescriptor(parts);
        }


        private static Tuple<ShaderTypes, IShaderStatement>? GetMainMethod(ShaderClass @class)
        {
            foreach (var method in ShaderMethods.Methods)
            {
                var member = @class.Members.FirstOrDefault(x => x is ShaderMethod) as ShaderMethod;

                if (member != null && member.Alias == method.Key)
                    return new(method.Value, member.Body);
            }

            return null;
        }


        private static IEnumerable<IShaderMember> DestructClassParam(ShaderClass @class, )
        {

        }
    }
}
