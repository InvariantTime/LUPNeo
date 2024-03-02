using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Generation.OpenGL
{
    static class ExpressionConverter
    {
        public static string GetTypeString(ShaderValueType type)
        {
            return type.Class switch
            {
                ShaderValueClasses.Primitive => ConvertPrimitive(type.Primitive),
                ShaderValueClasses.Texture => ConvertTexture(type.Texture),
                ShaderValueClasses.Struct => type.Alias,
                _ => throw new NotImplementedException()
            };
        }


        public static string ConvertPrimitive(ShaderPrimitiveTypes primitive)
        {
            return primitive switch
            {
                ShaderPrimitiveTypes.Bool => "bool",
                ShaderPrimitiveTypes.Int => "int",
                ShaderPrimitiveTypes.Uint => "uint",
                ShaderPrimitiveTypes.Float => "float",
                ShaderPrimitiveTypes.Double => "double",

                ShaderPrimitiveTypes.IVec2 => "ivec2",
                ShaderPrimitiveTypes.UVec2 => "uvec2",
                ShaderPrimitiveTypes.Vec2 => "vec2",
                ShaderPrimitiveTypes.DVec2 => "dvec2",

                ShaderPrimitiveTypes.IVec3 => "ivec3",
                ShaderPrimitiveTypes.UVec3 => "uvec3",
                ShaderPrimitiveTypes.Vec3 => "vec3",
                ShaderPrimitiveTypes.DVec3 => "dvec3",

                ShaderPrimitiveTypes.IVec4 => "ivec4",
                ShaderPrimitiveTypes.UVec4 => "uvec4",
                ShaderPrimitiveTypes.Vec4 => "vec4",
                ShaderPrimitiveTypes.DVec4 => "dvec4",

                ShaderPrimitiveTypes.Mat2 => "mat2",
                ShaderPrimitiveTypes.Mat3 => "mat3",
                ShaderPrimitiveTypes.Mat4 => "mat4",

                _ => throw new NotImplementedException()
            };
        }


        public static string ConvertTexture(ShaderTextureTypes texture)
        {
            return texture switch
            {
                ShaderTextureTypes.Texture1D => "sampler1D",
                ShaderTextureTypes.Texture2D => "sampler2D",
                ShaderTextureTypes.Texture3D => "sampler3D",
                ShaderTextureTypes.TextureCube => "samplerCube",
                ShaderTextureTypes.Texture2DArray => "sampler2DArray",
                _ => throw new NotImplementedException()
            };
        }
    }
}
