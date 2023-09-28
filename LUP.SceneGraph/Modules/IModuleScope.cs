using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Modules
{
    public interface IModuleScope : IReadOnlyCollection<SceneModule>
    {
        T? GetModule<T>() where T : SceneModule;
    }
}
