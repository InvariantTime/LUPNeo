using LUP.Graphics.Factories;
using LUP.Graphics.OpenGL.Factories;

namespace LUP.Graphics.OpenGL
{
    class OpenGLDevice : IGraphicsDevice
    {
        private const int maxUniformBuffers = 64;

        private readonly CommandList commandList;
        private readonly Dictionary<ConstantBufferKey, UniformBuffer> uniformBuffers;

        public ITextureFactory Textures { get; }

        public EffectFactory Effects => GLEffectFactory.Build;

        public FrameBufferFactory FBOs => GLFrameBufferFactory.Build;

        public DataBufferFactory DataBuffers => GLDataBufferFactory.Build;

        public OpenGLDevice(CommandList commandList)
        {
            this.commandList = commandList;

            Textures = new TextureFactory();
            uniformBuffers = new();
        }


        public IGraphicsCommandList GetCommandList()
        {
            return commandList;
        }


        public IConstantBuffer GetConstantBuffer(ConstantBufferKey key)
        {
            bool result = uniformBuffers.TryGetValue(key, out var value);

            if (result == false)
            {
                value = new UniformBuffer(key.Size, key.Binidng);
                uniformBuffers.Add(key, value);
            }

            return value!;
        }
    }
}
