using LUP.Graphics.Enums;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL
{
    static class OpenGLConverter
    {
        public static TextureTarget Convert(TextureTypes type)
        {
            return type switch
            {
                TextureTypes.Texture1D => TextureTarget.Texture1D,

                TextureTypes.Texture2D => TextureTarget.Texture2D,

                TextureTypes.Texture3D => TextureTarget.Texture3D,

                TextureTypes.TextureCube => TextureTarget.TextureCubeMap,

                TextureTypes.TextureArray => TextureTarget.Texture2DArray,

                _ => throw new NotSupportedException()
            };
        }


        public static PrimitiveType Convert(PrimitiveTypes type)
        {
            return type switch
            {
                PrimitiveTypes.Triangles => PrimitiveType.Triangles,
              
                PrimitiveTypes.TriangleStrip => PrimitiveType.TriangleStrip,

                PrimitiveTypes.TriangleFan => PrimitiveType.TriangleFan,
                
                PrimitiveTypes.Lines => PrimitiveType.Lines,
                
                PrimitiveTypes.LineLoop => PrimitiveType.LineLoop,
                
                PrimitiveTypes.LineStrip => PrimitiveType.LineStrip,

                PrimitiveTypes.QuadStrip => PrimitiveType.QuadStrip,

                PrimitiveTypes.Quads => PrimitiveType.Quads,
                
                PrimitiveTypes.Points => PrimitiveType.Points,

                PrimitiveTypes.Polygon => PrimitiveType.Polygon,

                _ => throw new NotImplementedException()
            };
        }


        public static PixelType Convert(PixelTypes type)
        {
            return type switch
            {
                PixelTypes.Byte => PixelType.Byte,

                PixelTypes.UnsignedByte => PixelType.UnsignedByte,

                PixelTypes.Short => PixelType.Short,

                PixelTypes.UnsignedShort => PixelType.UnsignedShort,

                PixelTypes.Int => PixelType.Int,

                PixelTypes.UnsignedInt => PixelType.UnsignedInt,

                PixelTypes.Float => PixelType.Float,

                PixelTypes.HalfFloat => PixelType.HalfFloat,

                PixelTypes.Bitmap => PixelType.Bitmap,

                _ => throw new NotSupportedException()
            };
        }


        public static PixelFormat Convert(PixelFormats type)
        {
            return type switch
            {
                PixelFormats.UnsignedShort => PixelFormat.UnsignedShort,

                PixelFormats.UnsignedInt => PixelFormat.UnsignedInt,

                PixelFormats.ColorIndex => PixelFormat.ColorIndex,

                PixelFormats.StencilIndex => PixelFormat.StencilIndex,

                PixelFormats.DepthComponent => PixelFormat.DepthComponent,

                PixelFormats.Red => PixelFormat.Red,

                PixelFormats.Green => PixelFormat.Green,

                PixelFormats.Blue => PixelFormat.Blue,

                PixelFormats.Alpha => PixelFormat.Alpha,

                PixelFormats.Rgb => PixelFormat.Rgb,

                PixelFormats.Rgba => PixelFormat.Rgba,

                PixelFormats.Luminance => PixelFormat.Luminance,

                PixelFormats.LuminanceAlpha => PixelFormat.LuminanceAlpha,

                PixelFormats.Bgr => PixelFormat.Bgr,

                PixelFormats.Bgra => PixelFormat.Bgra,

                PixelFormats.Ycrcb422Sgix => PixelFormat.Ycrcb422Sgix,

                PixelFormats.Ycrcb444Sgix => PixelFormat.Ycrcb444Sgix,

                PixelFormats.Rg => PixelFormat.Rg,

                PixelFormats.RgInteger => PixelFormat.RgInteger,

                PixelFormats.R5G6B5IccSgix => PixelFormat.R5G6B5IccSgix,

                PixelFormats.R5G6B5A8IccSgix => PixelFormat.R5G6B5A8IccSgix,

                PixelFormats.Alpha16IccSgix => PixelFormat.Alpha16IccSgix,

                PixelFormats.Luminance16IccSgix => PixelFormat.Luminance16IccSgix,

                PixelFormats.Luminance16Alpha8IccSgix => PixelFormat.Luminance16Alpha8IccSgix,

                PixelFormats.DepthStencil => PixelFormat.DepthStencil,

                PixelFormats.RedInteger => PixelFormat.RedInteger,

                PixelFormats.GreenInteger => PixelFormat.GreenInteger,

                PixelFormats.BlueInteger => PixelFormat.BlueInteger,

                PixelFormats.AlphaInteger => PixelFormat.AlphaInteger,

                PixelFormats.RgbInteger => PixelFormat.RgbInteger,

                PixelFormats.RgbaInteger => PixelFormat.RgbaInteger,

                PixelFormats.BgrInteger => PixelFormat.BgrInteger,

                PixelFormats.BgraInteger => PixelFormat.BgraInteger,

                _ => throw new NotSupportedException()
            };
        }


        public static ShaderType Convert(ShaderTypes type)
        {
            return type switch
            {
                ShaderTypes.Vertex => ShaderType.VertexShader,

                ShaderTypes.Pixel => ShaderType.FragmentShader,

                ShaderTypes.Geometry => ShaderType.GeometryShader,

                _ => throw new NotSupportedException()
            };
        }


        public static BufferTarget Convert(BufferTypes type)
        {
            return type switch
            {
                BufferTypes.Array => BufferTarget.ArrayBuffer,

                BufferTypes.Element => BufferTarget.ElementArrayBuffer,

                _ => throw new NotSupportedException()
            };
        }


        public static BufferUsageHint Convert(BufferUsages usage)
        {
            return usage switch
            {
                BufferUsages.StaticDraw => BufferUsageHint.StaticDraw,

                BufferUsages.DynamicDraw => BufferUsageHint.DynamicDraw,

                BufferUsages.StreamDraw => BufferUsageHint.StreamDraw,

                BufferUsages.StaticRead => BufferUsageHint.StaticRead,

                BufferUsages.DynamicRead => BufferUsageHint.DynamicRead,

                BufferUsages.StreamRead => BufferUsageHint.StreamRead,

                _ => throw new NotSupportedException()
            };
        }


        public static TextureUnit Convert(TextureBindings binding)
        {
            int b = (int)binding;
            return TextureUnit.Texture0 + b;
        }


        public static ShaderUniformTypes Convert(ActiveUniformType type)
        {
            return type switch
            {
                ActiveUniformType.Int => ShaderUniformTypes.Int,

                ActiveUniformType.Float => ShaderUniformTypes.Float,

                ActiveUniformType.Double => ShaderUniformTypes.Double,

                ActiveUniformType.Bool => ShaderUniformTypes.Bool,

                ActiveUniformType.UnsignedInt => ShaderUniformTypes.Uint,

                ActiveUniformType.FloatVec2 => ShaderUniformTypes.Vec2,

                ActiveUniformType.IntVec2 => ShaderUniformTypes.IVec2,

                ActiveUniformType.DoubleVec2 => ShaderUniformTypes.DVec2,

                ActiveUniformType.UnsignedIntVec2 => ShaderUniformTypes.UVec2,

                ActiveUniformType.FloatVec3 => ShaderUniformTypes.Vec3,

                ActiveUniformType.IntVec3 => ShaderUniformTypes.IVec3,

                ActiveUniformType.DoubleVec3 => ShaderUniformTypes.DVec3,

                ActiveUniformType.UnsignedIntVec3 => ShaderUniformTypes.UVec3,

                ActiveUniformType.FloatVec4 => ShaderUniformTypes.Vec4,

                ActiveUniformType.IntVec4 => ShaderUniformTypes.IVec4,

                ActiveUniformType.DoubleVec4 => ShaderUniformTypes.DVec4,

                ActiveUniformType.UnsignedIntVec4 => ShaderUniformTypes.UVec4,

                ActiveUniformType.FloatMat4 => ShaderUniformTypes.Mat4,

                _ => ShaderUniformTypes.None
            };
        }


        public static VertexAttribPointerType Convert(VertexAttribPointerTypes type)
        {
            return type switch
            {
                VertexAttribPointerTypes.Float => VertexAttribPointerType.Float,
                VertexAttribPointerTypes.Double => VertexAttribPointerType.Double,
                VertexAttribPointerTypes.Short => VertexAttribPointerType.Short,
                VertexAttribPointerTypes.Byte => VertexAttribPointerType.Short,
                VertexAttribPointerTypes.Int => VertexAttribPointerType.Int,
               
                VertexAttribPointerTypes.UnsignedInt => VertexAttribPointerType.UnsignedInt,
                VertexAttribPointerTypes.UnsignedByte => VertexAttribPointerType.UnsignedByte,
                VertexAttribPointerTypes.UnsignedShort => VertexAttribPointerType.UnsignedShort,

                VertexAttribPointerTypes.HalfFloat => VertexAttribPointerType.HalfFloat,

                _ => throw new NotImplementedException()
            };
        }


        public static DepthFunction Convert(DepthFunctions function)
        {
            return function switch
            {
                DepthFunctions.Never => DepthFunction.Never,

                DepthFunctions.Less => DepthFunction.Less,

                DepthFunctions.Greater => DepthFunction.Greater,

                DepthFunctions.Equal => DepthFunction.Equal,

                DepthFunctions.NotEqual => DepthFunction.Notequal,

                DepthFunctions.GreaterEqual => DepthFunction.Gequal,

                DepthFunctions.LessEqual => DepthFunction.Lequal,

                DepthFunctions.Always => DepthFunction.Always,

                _ => throw new NotImplementedException()
            };
        }


        public static ClearBufferMask Convert(ClearMask mask)
        {
            ClearBufferMask result = default;

            if (mask.HasFlag(ClearMask.Depth) == true)
                result |= ClearBufferMask.DepthBufferBit;

            if (mask.HasFlag(ClearMask.Color) == true)
                result |= ClearBufferMask.ColorBufferBit;

            if (mask.HasFlag(ClearMask.Stencil) == true)
                result |= ClearBufferMask.StencilBufferBit;

            return result;
        }
    }
}
