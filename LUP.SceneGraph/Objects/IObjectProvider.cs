using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Objects
{
    public interface IObjectProvider
    {
        IObjectScope GetObjects();
    }

    public interface IRootObjectProvider : IObjectProvider
    {
        IRootObjectScope GetRootObjects();
    }
}
