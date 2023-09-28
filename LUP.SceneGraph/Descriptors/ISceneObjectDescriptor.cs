using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Descriptors
{
    public interface ISceneObjectDescriptor
    {
        string Name { get; }

        void Handle(SceneObject @object);
    }
}
