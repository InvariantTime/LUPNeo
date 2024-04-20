using LUP.Graphics.Enums;
using LUP.Math;
using LUP.Math.Shaders;
using System.Collections.Immutable;

namespace LUP.Graphics.OpenGL
{
    delegate void UniformDelegate(int index, ShaderUniformTypes type, ValueType value);

    static class ShaderUniformDelegateInstance
    {
        private static ImmutableDictionary<ShaderUniformTypes, Action<int, ValueType>> accessors;

        public static readonly UniformDelegate Instance = Build();

        static ShaderUniformDelegateInstance()
        {
            accessors = ImmutableDictionary.Create<ShaderUniformTypes, Action<int, ValueType>>();
            Add<int>(ShaderUniformTypes.Int, ShaderAccessors.SetInt);
            Add<uint>(ShaderUniformTypes.Uint, ShaderAccessors.SetUint);
            Add<float>(ShaderUniformTypes.Float, ShaderAccessors.SetFloat);
            Add<double>(ShaderUniformTypes.Double, ShaderAccessors.SetDouble);
            Add<bool>(ShaderUniformTypes.Bool, (l, v) => 
                    ShaderAccessors.SetInt(l, v == true ? 1 : 0));

            Add<Vec2<int>>(ShaderUniformTypes.IVec2, ShaderAccessors.SetIVec2);
            Add<Vec2<uint>>(ShaderUniformTypes.UVec2, ShaderAccessors.SetUVec2);
            Add<Vector2>(ShaderUniformTypes.Vec2, ShaderAccessors.SetVec2);
            Add<Vec2<double>>(ShaderUniformTypes.DVec2, ShaderAccessors.SetDVec2);

            Add<Vec3<int>>(ShaderUniformTypes.IVec3, ShaderAccessors.SetIVec3);
            Add<Vec3<uint>>(ShaderUniformTypes.UVec3, ShaderAccessors.SetUVec3);
            Add<Vector3>(ShaderUniformTypes.Vec3, ShaderAccessors.SetVec3);
            Add<Vec3<double>>(ShaderUniformTypes.DVec3, ShaderAccessors.SetDVec3);

            Add<Vec4<int>>(ShaderUniformTypes.IVec4, ShaderAccessors.SetIVec4);
            Add<Vec4<uint>>(ShaderUniformTypes.UVec4, ShaderAccessors.SetUVec4);
            Add<Vector4>(ShaderUniformTypes.Vec4, ShaderAccessors.SetVec4);
            Add<Vec4<double>>(ShaderUniformTypes.DVec4, ShaderAccessors.SetDVec4);

            Add<Matrix4>(ShaderUniformTypes.Mat4, ShaderAccessors.SetMat4);
        }


        private static UniformDelegate Build()
        {
            return (index, type, value) =>
            {
                bool result = accessors.TryGetValue(type, out var accessor);

                if (result == false)
                    throw new Exception($"Unknown type {type}");

                accessor!.Invoke(index, value);
            };
        }


        private static void Add<T>(ShaderUniformTypes type, Action<int, T> accessor)
            where T : struct
        {
            Action<int, ValueType> result = (index, value) =>
            {
                if (value is not T t)
                    throw new InvalidCastException($"Unable to cast {nameof(T)} to {type}");

                accessor.Invoke(index, t);
            };

            accessors = accessors.Add(type, result);
        }
    }
}
