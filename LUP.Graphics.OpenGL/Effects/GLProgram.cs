﻿using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.Effects
{
    //TODO: internal
    public class GLProgram
    {
        private readonly int index;

        public int Index => index;

        public GLProgram(params ShaderData[] datas) : this(datas.AsEnumerable())
        {
        }


        public GLProgram(IEnumerable<ShaderData> datas)
        {
            index = GL.CreateProgram();
            int result;

            foreach (var descriptor in datas)
            {
                int shader = GL.CreateShader(OpenGLConverter.Convert(descriptor.Type));
                GL.ShaderSource(shader, descriptor.Source);
                GL.CompileShader(shader);

                GL.GetShader(shader, ShaderParameter.CompileStatus, out result);

                if (result == 0)
                {
                    GL.GetShaderInfoLog(shader, out var info);
                    throw new InvalidOperationException("Unable to create shader: " + info);
                }

                GL.AttachShader(index, shader);
            }

            GL.LinkProgram(index);
            GL.GetProgram(index, GetProgramParameterName.LinkStatus, out result);

            if (result == 0)
            {
                GL.GetProgramInfoLog(index, out string info);
                throw new InvalidOperationException("Unable to create program: " + info);
            }

            GL.UseProgram(0);
        }


        public void Bind()
        {
            GL.UseProgram(index);
        }


        public static void Unbind()
        {
            GL.UseProgram(0);
        }
    }
}
