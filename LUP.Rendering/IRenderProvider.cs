using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering
{
    public interface IRenderProvider
    {
        bool Enable { get; }

        void Visit(IRenderVisitor visitor);
    }
}
