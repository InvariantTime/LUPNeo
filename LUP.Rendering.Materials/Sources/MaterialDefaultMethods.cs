using LUP.Rendering.Effects.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Materials.Sources
{
    public static class MaterialDefaultMethods
    {
        public static readonly MaterialMethod GetAlbedo = new("getAlbedo", "return vec4(1.0);", "vec4");

        public static readonly MaterialMethod GetGlobal = new("getGlobal", "return color * albedo;", "vec4",
            new ShaderParam("vec4", "albedo"), new ShaderParam("vec4", "light"));
    }
}
