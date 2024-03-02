using LUP.Graphics.Commanding;
using LUP.Graphics.OpenGL.Resources;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.Commanding
{
    class GLShaderCommands : ShaderCommands
    {
        private readonly OpenGLFactory resources;

        public GLShaderCommands(OpenGLFactory resources)
        {
            this.resources = resources;
        }


        public override void BindShader(GraphicsResource shader)
        {
            if (shader.Type != GraphicsResourceTypes.Shader)
                throw new InvalidOperationException($"{shader} is not shader");

            var res = resources.GetResource(shader);
            res?.Bind();
        }


        public override void BindShaderToConstantBuffer(ShaderConstantBinding binding)
        {
            if (binding.Shader.Type != GraphicsResourceTypes.Shader)
                throw new InvalidOperationException($"{binding.Shader} is not shader");

            var shader = resources.GetResource(binding.Shader) as GLShader
                ?? throw new NullReferenceException("Unable to get shader resource");

            shader.BindConstantBuffer(binding.Index, binding.BindingName);
        }


        public override void SetShaderUniform(string name, ValueType value)
        {
        }


        public override void UnbindShader()
        {
            GL.UseProgram(0);
        }
    }
}
