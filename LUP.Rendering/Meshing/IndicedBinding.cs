using LUP.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Meshing
{
    public class IndicedBinding
    {
        public IDataBuffer EBO { get; }

        public IndicedBinding(IDataBuffer ebo)
        {
            EBO = ebo;
        }
    }
}
