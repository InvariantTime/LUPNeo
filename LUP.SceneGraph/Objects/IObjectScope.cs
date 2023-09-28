using LUP.SceneGraph.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Objects
{
    public interface IObjectScope : IReadOnlyCollection<SceneObject>
    {
        //TODO: descriptor for object
        SceneObject Instantiate(ISceneObjectDescriptor? descriptor);

        void Remove(SceneObject @object);
    }
}
