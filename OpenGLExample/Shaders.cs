using LUP.Graphics;
using LUP.Graphics.Enums;
using LUP.Graphics.OpenGL.Effects;

namespace OpenGLExample
{
    public class Shaders
    {
        private static readonly string fragment = """
            #version 430

            out vec4 color_out;

            in vec2 uv_coord;

            uniform sampler2D screen;

            void main()
            {
                color_out = texture(screen, uv_coord);
            }

            """;

        private static readonly string vertex = """
            #version 430

            layout(location = 0) in vec2 pos;
            layout(location = 1) in vec2 tex;

            out vec2 uv_coord;

            void main()
            {
                gl_Position = vec4(pos, 0.0, 1.0);
                uv_coord = tex;
            }

            """;


        public static readonly GLProgram ScreenShader = new(new ShaderData[]
        {
            new ShaderData(ShaderTypes.Vertex, vertex),
            new ShaderData(ShaderTypes.Pixel, fragment)
        });
    }
}
