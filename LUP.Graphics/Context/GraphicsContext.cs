using LUP.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    public class GraphicsContext : IEnumerable<GraphicsCommand>
    {
        private readonly Queue<GraphicsCommand> commands;

        public GraphicsContext()
        {
            commands = new();
        }


        public void AddCommand(uint command, object? data = null)
        {
            commands.Enqueue(new GraphicsCommand(command, data));
        }


        public void ResetCommands()
        {
            commands.Clear();
        }


        public IEnumerator<GraphicsCommand> GetEnumerator()
        {
            return commands.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
