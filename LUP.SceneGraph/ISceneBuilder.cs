using LUP.SceneGraph.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph
{
    interface ISceneBuilder
    {
        SceneProvider BuildScene(ISceneDescriptor? descriptor);
    }
}
