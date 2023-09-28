using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client
{
    [Flags]
    public enum WindowFlags
    {
        Metal = 0x20000000,
        Opengl = 0x2,
        Vulkan = 0x10000000,
    }
}
