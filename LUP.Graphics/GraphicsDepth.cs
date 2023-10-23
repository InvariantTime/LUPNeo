using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    public struct GraphicsDepth
    {
        public static readonly GraphicsDepth Identity = new()
        {
            Enable = true,
            WriteEnable = true,
            Function = DepthFunctions.Less
        };

        public bool Enable { get; set; }

        public bool WriteEnable { get; set; }

        public DepthFunctions Function { get; set; }
    }


    public enum DepthFunctions
    {
       Never = 0,

       Less = 1,

       Equal = 2,

       LessEqual = 3,

       Greater = 4,

       GreaterEqual = 5,

       NotEqual = 6,

       Always = 7
    }
}
