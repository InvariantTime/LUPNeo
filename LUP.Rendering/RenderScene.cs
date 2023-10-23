using LUP.Rendering.RenderTargets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering
{
    public readonly struct RenderScene
    {
        public IRenderCompositor Compositor { get; init; }
        
        public ICamera View { get; init; }
    }
}
