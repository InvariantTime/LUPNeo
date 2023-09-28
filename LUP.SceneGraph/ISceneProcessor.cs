using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LUP.SceneGraph.Descriptors;

namespace LUP.SceneGraph
{
    public interface ISceneProcessor : IApplicationStage
    {
        SceneProvider? Provider { get; }

        void LoadScene(ISceneDescriptor? descriptor);
    }
}
