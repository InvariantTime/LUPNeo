using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
    public interface ILoopPipeline : IDisposable, IAsyncDisposable
    {
        void AddStage(IApplicationStage stage);

        void Run(LoopContext context);
    }
}
