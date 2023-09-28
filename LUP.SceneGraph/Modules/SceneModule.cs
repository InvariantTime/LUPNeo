using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Modules
{
    public abstract class SceneModule : DisposableObject
    {
        public int UpdatePerSecond { get; protected set; } = 0;

        public void Update()
        {

        }
    }
}
