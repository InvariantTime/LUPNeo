using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    public static class GraphicsCommands//TODO: change commands bits
    {
        //Drawing
        public static readonly uint Clear = 0x01;

        public static readonly uint Draw = 0x02;

        public static readonly uint DrawInstance = 0x03;

        public static readonly uint BindVertexFormat = 0x04;

        public static readonly uint UnbindVertexFormat = 0x05;

        //Shader
        public static readonly uint BindShader = 0x01_00;

        public static readonly uint UnbindShader = 0x02_00;

        public static readonly uint SetUniform = 0x05_00;

        public static readonly uint BindShaderToConstantBuffer = 0x08_00;

        //State
        public static readonly uint SetState = 0x11_00;

        public static readonly uint SetRenderTarget = 0x14_00;

        //Texturing
        public static readonly uint BindTexture = 0x0A_00;

        public static readonly uint UnbindTexture = 0x1A_00;

        public static readonly uint SetTextureSlot = 0x2A_00;

        //Buffers
        public static readonly uint BindBuffer = 0x01_00_00;

        public static readonly uint UnbindBuffer = 0x02_00_00;

        public static readonly uint UpdateBuffer = 0x04_00_00;
    }
}
