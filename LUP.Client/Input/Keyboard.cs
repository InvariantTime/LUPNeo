using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client.Input
{
    public interface IKeyboard
    {
        event EventHandler<KeyboardEventArgs>? KeyPressed;

        event EventHandler<KeyboardEventArgs>? KeyReleased;

        bool IsKeyPressed(KeyboardKeys key);
    }
}
