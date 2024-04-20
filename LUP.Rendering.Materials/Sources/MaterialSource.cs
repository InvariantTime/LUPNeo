using LUP.Graphics;
using LUP.Graphics.Enums;
using LUP.Rendering.Effects.Generation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Materials.Sources
{
    public class MaterialSource
    {
        private readonly List<ShaderMethod> methods;
        private readonly List<ShaderParam> uniforms;
        private readonly List<ShaderDefine> defines;

        public string Main { get; }

        public ShaderTypes Type { get; }

        public MaterialSource(string main, ShaderTypes type)
        {
            Main = main;
            Type = type;

            defines = new();
            methods = new();
            uniforms = new();
        }


        public void AddMethod(MaterialMethod method)
        {
            var result = new ShaderMethod
            {
                Body = method.Body,
                Name = method.Name,
                Args = method.Args,
                Return = method.Return
            };

            methods.Add(result);
        }


        public void AddUniform(MaterialParameter parameter, string type)
        {
            var uniform = MaterialUniformResolver.Resolve(parameter, type);
            uniforms.Add(uniform);
        }


        public void AddDefine(string name, string? value = null)
        {
            defines.Add(new(name, value ?? string.Empty));   
        }


        public IntermediateRawShader ToShader()
        {
            return new IntermediateRawShader
            {
                Main = Main,
                Uniforms = uniforms,
                Methods = methods,
                Defines = defines
            };
        }
    }
}
