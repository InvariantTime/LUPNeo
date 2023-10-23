using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.Effects
{
    public interface IUniformData
    {
        string Name { get; }

        EffectUniformTypes Type { get; }
    }
}
