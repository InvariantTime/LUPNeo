using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Components
{
    public interface IComponentPipeline
    {
        bool Handle(ComponentContext context, ComponentOperations operation);
    }
}
