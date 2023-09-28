using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client.Input
{
    public interface IInputProcessor : IApplicationStage
    {
        IInputHandler Input { get; }
    }
}
