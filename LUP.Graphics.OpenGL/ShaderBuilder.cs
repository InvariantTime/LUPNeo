using LUP.Graphics.OpenGL.Resources;
using LUP.Graphics.Resources;
using LUP.Math;
using LUP.Math.Shaders;
using OpenTK.Graphics.OpenGL;
using System.Collections.Immutable;

namespace LUP.Graphics.OpenGL
{
    static class ShaderBuilder
    {
        private const int maxSamplerCounts = 31;

        public static GLShader Build(ShaderDescriptor descriptor)
        {
            int[] shaders = new int[descriptor.Parts.Count()];

            for (int i = 0; i < shaders.Length; i++)
            {
                var source = descriptor.Parts[i].Source;

                var type = OpenGLConverter.Convert(descriptor.Parts[i].Type);
                int shader = GL.CreateShader(type);
                GL.ShaderSource(shader, source);
                GL.CompileShader(shader);

                GL.GetShader(shader, ShaderParameter.CompileStatus, out int param);

                if (param == 0)
                {
                    var log = GL.GetShaderInfoLog(shader);
                    throw new Exception(log);
                }

                shaders[i] = shader;
            }

            int index = GL.CreateProgram();

            for (int i = 0; i < shaders.Length; i++)
                GL.AttachShader(index, shaders[i]);

            GL.LinkProgram(index);
            GL.GetProgram(index, GetProgramParameterName.LinkStatus, out int programStatus);

            if (programStatus == 0)
            {
                var log = GL.GetProgramInfoLog(index);
                throw new Exception(log);
            }

            for (int i = 0; i < shaders.Length; i++)
                GL.DeleteShader(shaders[i]);

            ValidateSamplers(index);

            GL.GetProgram(index, GetProgramParameterName.ActiveUniforms, out int count);
            Dictionary<string, int> uniforms = new();

            for(int i = 0; i < count; i++)
            {
                var name = GL.GetActiveUniform(index, i, out _, out _);
                uniforms.Add(name, i);
            }

            return new GLShader(uniforms.ToImmutableDictionary(), index);
        }


        private static void ValidateSamplers(int index)
        {
            //TODO: Samplers
            //GL.GetProgram(index, GetProgramParameterName.);
        }
    }
}
