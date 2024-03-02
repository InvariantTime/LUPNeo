using LUP.Graphics.Commanding;
using LUP.Graphics.OpenGL.Resources;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.Commanding
{
    class GLTexturingCommands : TexturingCommands
    {
        private readonly OpenGLFactory resources;

        public GLTexturingCommands(OpenGLFactory resources)
        {
            this.resources = resources;
        }


        public override void BindTexture(GraphicsResource texture)
        {
            if (texture.Type != GraphicsResourceTypes.Texture)
                throw new InvalidOperationException($"{nameof(texture)} is not texture");

            var res = resources.GetResource(texture);
            res?.Bind();
        }


        public override void SetTextureSlot(uint index)
        {
            GL.ActiveTexture((TextureUnit)((uint)TextureUnit.Texture0 + index));
        }


        public override void UnbindTexture(GraphicsResource texture)
        {
            if (texture.Type != GraphicsResourceTypes.Texture)
                throw new InvalidOperationException($"{nameof(texture)} is not texture");

            var res = resources.GetResource(texture);
            res?.Unbind();
        }
    }
}
