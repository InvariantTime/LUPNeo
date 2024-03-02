using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL
{
    public static class GLState
    {
        public static void SetDepthEnable(bool value)
        {
            if (value == true)
                GL.Enable(EnableCap.DepthTest);
            else
                GL.Disable(EnableCap.DepthTest);
        }


        public static void SetDepthMaskEnable(bool value)
        {
            GL.DepthMask(value);
        }


        public static void SetDepthFunction(DepthFunctions function)
        {
            var func = OpenGLConverter.Convert(function);
            GL.DepthFunc(func);
        }


        public static void SetStencilEnable(bool value)
        {
            if (value == true)
                GL.Enable(EnableCap.StencilTest);
            else
                GL.Disable(EnableCap.StencilTest);
        }


        public static void SetStencilMask(int mask)
        {
            GL.StencilMask(mask);
        }


        public static void SetStencilFunction()
        {

        }
    }
}
