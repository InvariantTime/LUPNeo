using LUP.Graphics;
using LUP.Graphics.Enums;
using LUP.Graphics.OpenGL.Effects;
using LUP.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendering_Example
{
    public static class Shaders
    {
        private static readonly string vertex = """
            #version 410

            layout(location = 0) in vec3 pos;
            layout(location = 1) in vec2 uv_in;
            layout(location = 2) in vec3 normal_in;

            layout(std140, binding = 2) uniform SceneData
            {
                mat4 projection;
                mat4 view;
                mat4 viewWithoutPos;
                vec3 viewPos;
                vec2 resolution;
                float time;
            } scene_data;

            out vec3 normal;
            out vec2 uv;

            void main()
            {
                gl_Position = scene_data.projection * scene_data.view * vec4(pos, 1.0);
                normal = normal_in;
                uv = uv_in;
            }
            """;

        private static readonly string fragment = """
            #version 410

            out vec4 color_out;

            in vec3 normal;
            in vec2 uv;

            uniform vec3 color_in;

            layout(std140, binding = 2) uniform SceneData
            {
                mat4 projection;
                mat4 view;
                mat4 viewWithoutPos;
                vec3 viewPos;
                vec2 resolution;
                float time;
            } scene_data;

            vec3 getColor();

            void main()
            {
                vec3 color = vec3(1.0);
                float ambientCoef = 0.3;
                float diffuseCoef = 0.6;

                float y = cos(scene_data.time);
                float z = sin(scene_data.time);

                vec3 dir = vec3(0.0, y, z);

                vec4 ambientColor = vec4(color, 1.0) * ambientCoef;
                vec4 diffuseColor = vec4(0.0);
                
                float diffuseFactor = dot(normalize(normal), -dir);

                if (diffuseFactor > 0)
                    diffuseColor = vec4(color, 1.0) * diffuseCoef * diffuseFactor;

                color_out = vec4(getColor(), 1.0) * (diffuseColor + ambientColor);
            }

            vec3 getColor()
            {
                return color_in;
            }
            """;


        private static readonly string fragment2 = """
            
            @export Out {
                out vec4 color_out;
            }

            @export In {
                in vec3 normal;
                in vec3 uv;
            }

            @export Uniforms {
                vec3 color_in;
            }

            @dependency Lighting;


            @export Main {
                out_color = vec4(color_in, 1.0);

            }
            """;


        public static IEffect CreateShader(IGraphicsDevice device)
        {
            var shader = device.Effects.Invoke(new EffectDescriptor(
                new ShaderData(ShaderTypes.Vertex, vertex),
                new ShaderData(ShaderTypes.Pixel, fragment)
            ));

            return shader;
        }


        public static IEffect CreateShader2(IGraphicsDevice device)
        {
            var shader = device.Effects.Invoke(new EffectDescriptor(
                new ShaderData(ShaderTypes.Vertex, vertex),
                new ShaderData(ShaderTypes.Pixel, fragment2)
            ));

            return shader;
        }
    }
}
