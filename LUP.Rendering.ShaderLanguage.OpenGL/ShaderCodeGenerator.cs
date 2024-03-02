using LUP.Graphics.Enums;
using LUP.Rendering.Language.Expressions;
using LUP.Rendering.Language.Objects;
using System.Text;
using System.Text.RegularExpressions;

namespace LUP.Rendering.Language.Generation
{
    class ShaderCodeGenerator
    {
        private static readonly Regex clearRegex =
            new(@"%[A-Z]+%", RegexOptions.None, TimeSpan.FromSeconds(5));

        private readonly IShaderGenerationProvider provider;

        public ShaderCodeGenerator(IShaderGenerationProvider provider)
        {
            this.provider = provider;
        }


        public string Generate(ShaderCodeDescriptor descriptor, ShaderSource source)
        {
            var mainExpr = new StringBuilder();
            descriptor.Main.Interpret(provider.ExpressionGenerator, mainExpr);

            var members = descriptor.Class.Members;
            var generator = provider.MemberGenerator;

            var template = provider.ShaderTemplate;

            var methods = GenerateMembers<ShaderMethod>(descriptor, (b, d, o) =>
            {
                if (ShaderMethods.Methods.FirstOrDefault(x => x.Key == o.Alias).Key != null)
                    return;

                generator.GenerateMethod(b, d, o);
            });

            var cbuffers = GenerateMembers<ShaderCBuffer>(descriptor, generator.GenerateCBuffer);
            var attribs = GenerateMembers<ShaderAttribute>(descriptor, generator.GenerateAttribute);

            template = GenerationTokens.ShaderMethod.Replace(template, methods);
            template = GenerationTokens.ShaderCBuffer.Replace(template, cbuffers);
            template = GenerationTokens.ShaderAttribute.Replace(template, attribs);

            //Handle main method code
            provider.Handler.HandleMainCode(descriptor, mainExpr);
            template = GenerationTokens.ShaderMain.Replace(template, mainExpr.ToString());

            //end handle
            template = provider.Handler.HandleFinishCode(descriptor, template);
            return Clear(template);
        }


        private static string GenerateMembers<T>(ShaderCodeDescriptor descriptor, 
            Action<StringBuilder, ShaderCodeDescriptor, T> action)
            where T : class, IShaderMember
        {
            var objects = SelectFrom<IShaderMember, T>(descriptor.Class.Members);

            if (objects.Count() == 0)
                return string.Empty;

            var builder = new StringBuilder();

            foreach (var obj in objects)
                action.Invoke(builder, descriptor, obj);

            return builder.ToString();
        }


        private static string Clear(string source)
        {
            return clearRegex.Replace(source, string.Empty);
        }


        private static IEnumerable<T2> SelectFrom<T1, T2>(IEnumerable<T1> enumerable)
            where T2 : class, T1 where T1 : class
        {
            return from x in enumerable
                   where x is T2
                   select x as T2;
        }
    }

    public readonly struct ShaderCodeDescriptor
    {
        public required ShaderClass Class { get; init; }

        public required ShaderTypes Type { get; init; }

        public required IShaderStatement Main { get; init; }

        public required IEnumerable<IShaderMember> Members { get; init; }
    }
}
