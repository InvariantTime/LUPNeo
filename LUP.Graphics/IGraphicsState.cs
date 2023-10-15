using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    //TODO Graphics state
    public interface IGraphicsState
    {
        IGraphicsDepth Depth { get; }

        IGraphicsStencil Stencil { get; }

        IBlendState Blend { get; }

        void Init();
    }

    public interface IGraphicsDepth
    {
    }

    public interface IGraphicsStencil
    {
    }

    public interface IBlendState
    {

    }
}
