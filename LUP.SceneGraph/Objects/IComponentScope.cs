using LUP.SceneGraph.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Objects
{
    public interface IComponentProvider
    {
        IComponentScope Components { get; }
    }

    public interface IComponentScope : IReadOnlyCollection<ComponentBase>
    {
        bool AddComponent(ComponentBase component);

        bool RemoveComponent(ComponentBase component);
    }
}
