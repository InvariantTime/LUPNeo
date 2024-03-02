using LUP.Graphics.Commanding;
using LUP.Graphics.OpenGL.Resources;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL.Commanding
{
    class GLStateCommands : StateCommands
    {
        private readonly OpenGLFactory resources;

        public GLStateCommands(OpenGLFactory resources)
        {
            this.resources = resources;
        }


        public override void SetRenderTarget(GraphicsResource renderTarget)
        {
            if (renderTarget.Type != GraphicsResourceTypes.RenderTarget)
                throw new InvalidOperationException($"{renderTarget} is not render target");

            var res = resources.GetResource(renderTarget);
            res?.Bind();
        }


        public override void SetState(GraphicsState state)
        {
            //Depth
            GLState.SetDepthEnable(state.Depth.Enable);
            GLState.SetDepthMaskEnable(state.Depth.WriteEnable);
            GLState.SetDepthFunction(state.Depth.Function);

            //Stencil
            

            //Blend
        }
    }
}
