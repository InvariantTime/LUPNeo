using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    public struct GraphicsBlend
    {
        public BlendModes Mode { get; set; }
    }

    public enum BlendModes
    {
        Zero = 0,

        One = 1
    }
}
