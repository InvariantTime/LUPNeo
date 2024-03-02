using LUP.Rendering.Language.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Generation
{
    public interface IShaderMemberGenerator
    {
        void GenerateCBuffer(StringBuilder builder, ShaderCodeDescriptor descriptor, ShaderCBuffer cBuffer);

        void GenerateMethod(StringBuilder builder, ShaderCodeDescriptor descriptor, ShaderMethod method);

        void GenerateParam(StringBuilder builder, ShaderCodeDescriptor descriptor, ShaderParam param);

        void GenerateAttribute(StringBuilder builder, ShaderCodeDescriptor descriptor, ShaderAttribute attribute);
    }
}
