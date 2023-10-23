using LUP.Rendering.Lighting;
using LUP.SceneGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Components
{
    public class LightComponent : ActivableComponent, IRenderProvider
    {
        public ILight? Light { get; set; }

        public void Visit(IRenderVisitor visitor)
        {
            if (Light == null)
                return;

            visitor.Visit(Light);
        }
    }
}
