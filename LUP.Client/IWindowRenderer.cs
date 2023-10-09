using LUP.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client
{
    public interface IWindowRenderer
    {
        void Init(IntPtr window);

        void Render();

        void Resize(Vector2 size);
    }
}
