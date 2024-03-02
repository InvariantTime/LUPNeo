using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph
{
    public interface ISceneScheduler
    {
        void Schedule();

        Task ScheduleAsync();
    }
}
