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
    }
}
