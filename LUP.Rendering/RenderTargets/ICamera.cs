using LUP.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.RenderTargets
{
    public interface ICamera
    {
        Matrix4 GetView();

        Matrix4 GetProjection();
    }
}
