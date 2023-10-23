using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph
{
    public partial class TransformComponent : ComponentBase, IObjectProvider
    {
        public TransformComponent? ParentTransform
        {
            get
            {
                return null;    
            }
        }


        public void SetParent(TransformComponent component)
        {
            
        }
    }
}
