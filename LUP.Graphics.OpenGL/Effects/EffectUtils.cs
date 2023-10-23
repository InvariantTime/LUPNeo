using LUP.Graphics.Effects;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL.Effects
{
    static class EffectUtils
    {
        public static IEnumerable<GLUniform> GenerateUniforms(GLProgram program)
        {
            GL.GetProgram(program.Index, GetProgramParameterName.ActiveUniforms, out int count);

            for (int i = 0; i < count; i++)
            {
                string name = GL.GetActiveUniform(program.Index, i, out _, out ActiveUniformType t);
                var type = OpenGLConverter.Convert(t);

                if (type == EffectUniformTypes.None)
                    continue;

                int location = GL.GetUniformLocation(program.Index, name);

                yield return new GLUniform
                {
                    Name = name,
                    Type = type,
                    Index = location
                };
            }
        }
    }
}
