using LUP.Graphics.Enums;
using LUP.Rendering.Language.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Generation.OpenGL
{
    class ShaderGenerationHandler : IShaderGenerationHandler
    {
        private static readonly Regex versionRegex = new(@"%VERSION%", RegexOptions.None, TimeSpan.FromSeconds(5));
        private static readonly Regex methodDefRegex = new(@"%METHODDEF%", RegexOptions.None, TimeSpan.FromSeconds(5));
        private static readonly Regex outParamRegex = new(@"%OUTPARAM%", RegexOptions.None, TimeSpan.FromSeconds(5));

        public string HandleFinishCode(ShaderCodeDescriptor descriptor, string source)
        {
            source = versionRegex.Replace(source, "430");
            source = methodDefRegex.Replace(source, BuildMethodDefines(descriptor));
            
            if (descriptor.Type == ShaderTypes.Vertex)
            {

            }

            return source;
        }


        public void HandleMainCode(ShaderCodeDescriptor descriptor, StringBuilder source)
        {
            if (descriptor.Type == ShaderTypes.Vertex)
            {
                
            }
            else if (descriptor.Type == ShaderTypes.Geometry)
            {

            }
        }


        private static string BuildMethodDefines(ShaderCodeDescriptor descriptor)
        {
            var builder = new StringBuilder();

            foreach (var member in descriptor.Class.Members)
            {
                if (member is ShaderMethod method)
                {
                    if (method.Body == descriptor.Main)
                        continue;

                    builder.Append($"void {method.Alias}(");
                    builder.AppendJoin(',', method.Args.Select(x => $"{ExpressionConverter.GetTypeString(x.Type)} {x.Alias}"));
                    builder.AppendLine(");");
                }
            }

            return builder.ToString();
        }
    }
}
