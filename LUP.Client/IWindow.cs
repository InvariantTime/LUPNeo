using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client
{
    public interface IWindow
    {
        string Title { get; set; }

        void Render();
    }
}
