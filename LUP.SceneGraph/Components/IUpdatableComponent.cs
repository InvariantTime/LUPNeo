using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Components
{
    public interface IUpdatableComponent
    {
        void Update();
    }


    public interface IAsyncUpdatableComponent
    {
        Task Update();
    }
}
