using LUP.Rendering.Language.Expressions;
using LUP.Rendering.Language.Objects;
using System.Text;

namespace LUP.Rendering.Language.Generation.OpenGL
{
    class ShaderMemberGenerator : IShaderMemberGenerator
    {
        private readonly IShaderVisitor<StringBuilder> generator;

        public ShaderMemberGenerator(IShaderVisitor<StringBuilder> generator)
        {
            this.generator = generator;
        }


        public void GenerateAttribute(StringBuilder builder, ShaderCodeDescriptor descriptor, ShaderAttribute attribute)
        {
            var type = ExpressionConverter.ConvertPrimitive(attribute.Primitive);

            if (descriptor.Type == Graphics.Enums.ShaderTypes.Vertex)
            {
                builder.AppendLine($"layout(location = {attribute.Pointer}) in {type} {attribute.Alias};");
            }
        }


        public void GenerateCBuffer(StringBuilder builder, ShaderCodeDescriptor descriptor, ShaderCBuffer cBuffer)
        {
            builder.AppendLine($"layout(std140) uniform {cBuffer.Name} {{");

            foreach (var param in cBuffer.Params)
                builder.AppendLine($"{ExpressionConverter.GetTypeString(param.Type)} {param.Alias};");

            builder.AppendLine($"}} {cBuffer.Alias};");
        }


        public void GenerateMethod(StringBuilder builder, ShaderCodeDescriptor descriptor, ShaderMethod method)
        {
            builder.Append($"void {method.Alias}(");
            builder.AppendJoin(',', method.Args.Select(x => $"{ExpressionConverter.GetTypeString(x.Type)} {x.Alias}"));
            builder.AppendLine("){");
            method.Body.Interpret(generator, builder);
            builder.Append('}');
            builder.AppendLine();
        }


        public void GenerateParam(StringBuilder builder, ShaderCodeDescriptor descriptor, ShaderParam param)
        {
        }
    }
}
