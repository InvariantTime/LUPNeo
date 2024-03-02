using LUP.Graphics.Commanding;
using LUP.Graphics.OpenGL.Resources;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL.Commanding
{
    class GLBufferCommands : BufferCommands
    {
        private readonly OpenGLFactory factory;

        public GLBufferCommands(OpenGLFactory factory)
        {
            this.factory = factory;
        }


        public override void BindBuffer(GraphicsResource buffer)
        {
            if (buffer.Type != GraphicsResourceTypes.Buffer)
                throw new InvalidOperationException($"{buffer} is not buffer");

            var res = factory.GetResource(buffer);
            res?.Bind();
        }


        public override void UnbindBuffer(GraphicsResource buffer)
        {
            if (buffer.Type != GraphicsResourceTypes.Buffer)
                throw new InvalidOperationException($"{buffer} is not buffer");

            var res = factory.GetResource(buffer);
            res?.Unbind();
        }


        public override void UpdateBuffer(GraphicsResource buffer, BufferData data)
        {
            if (buffer.Type != GraphicsResourceTypes.Buffer)
                throw new InvalidOperationException($"{buffer} is not buffer");

            var res = factory.GetResource(buffer) as IGLBuffer;
            res?.Update(data, 0);
        }
    }
}
