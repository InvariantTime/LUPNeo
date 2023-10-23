using LUP.Graphics;
using LUP.Rendering.Lighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering
{
    public static class DefaultConstantBuffers
    {
        public static readonly ConstantBufferKey SceneData = ConstantBufferKey.New("SceneData", 240, 2);

        public static readonly ConstantBufferKey Lighting = ConstantBufferKey.New("Lighting", LightSettings.BufferSize, 3);
    }
}