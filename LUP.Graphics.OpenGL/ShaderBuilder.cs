using LUP.Graphics.OpenGL.Resources;
using LUP.Graphics.Resources;
using LUP.Math;
using LUP.Math.Shaders;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL
{
    static class ShaderBuilder
    {
        private const int maxSamplerCounts = 31;

        private static ImmutableDictionary<Type, Action<int, ValueType>> actions;

        static ShaderBuilder()
        {
            actions = ImmutableDictionary.Create<Type, Action<int, ValueType>>();
            AddAccessor<float>(ShaderAccessors.SetFloat);
            AddAccessor<int>(ShaderAccessors.SetInt);
            AddAccessor<double>(ShaderAccessors.SetDouble);
            AddAccessor<uint>(ShaderAccessors.SetUint);

            AddAccessor<Vector2>(ShaderAccessors.SetVec2);
            AddAccessor<Vec2<int>>(ShaderAccessors.SetIVec2);
            AddAccessor<Vec2<double>>(ShaderAccessors.SetDVec2);
            AddAccessor<Vec2<uint>>(ShaderAccessors.SetUVec2);

            AddAccessor<Vector3>(ShaderAccessors.SetVec3);
            AddAccessor<Vec3<int>>(ShaderAccessors.SetIVec3);
            AddAccessor<Vec3<double>>(ShaderAccessors.SetDVec3);
            AddAccessor<Vec3<uint>>(ShaderAccessors.SetUVec3);

            AddAccessor<Vector4>(ShaderAccessors.SetVec4);
            AddAccessor<Vec4<int>>(ShaderAccessors.SetIVec4);
            AddAccessor<Vec4<double>>(ShaderAccessors.SetDVec4);
            AddAccessor<Vec4<uint>>(ShaderAccessors.SetUVec4);

            AddAccessor<Matrix4>(ShaderAccessors.SetMat4);
        }


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

            return new GLShader(ImmutableDictionary.Create<string, Uniform>(), index);
        }


        private static void ValidateSamplers(int index)
        {
            //GL.GetProgram(index, GetProgramParameterName.);
        }



        private static void AddAccessor<T>(Action<int, T> action) where T : struct
        {
            actions = actions.Add(typeof(T), (l, v) =>
            {
                if (v is not T o)
                    throw new InvalidOperationException($"Unknown parameter {v.GetType()} for shader");

                action.Invoke(l, o);
            });
        }
    }
}
