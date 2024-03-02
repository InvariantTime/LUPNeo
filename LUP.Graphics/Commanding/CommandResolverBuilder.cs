using LUP.Graphics.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.Commanding
{
    static class CommandResolverBuilder
    {
        private static readonly Action<GraphicsCommand> terminal = _ => { };

        public static Action<GraphicsCommand> Build(IGraphicsCommandList list)
        {
            var collector = new Collector();
            list.ShaderCommands.InitializeCommands(collector);
            list.TexturingCommands.InitializeCommands(collector);
            list.StateCommands.InitializeCommands(collector);
            list.DrawingCommands.InitializeCommands(collector);
            list.PlatformCommands?.InitializeCommands(collector);
            list.BufferCommands.InitializeCommands(collector);

            return Chain(collector);
        }


        private static Action<GraphicsCommand> Chain(IEnumerable<(uint Type, Action<object?> Action)> actions)
        {
            static Action<GraphicsCommand> BuildAction((uint Type, Action<object?> Action) data,
                Action<GraphicsCommand> next)
            {
                return (c) =>
                {
                    if (c.Type == data.Type)
                    {
                        data.Action.Invoke(c.Data);
                    }
                    else
                    {
                        next.Invoke(c);
                    }
                };
            }

            var current = terminal;

            foreach (var action in actions)
                current = BuildAction(action, current);

            return current;
        }

        private class Collector : IGraphicsCommandCollector, IEnumerable<(uint, Action<object?>)>
        {
            private readonly List<(uint, Action<object?>)> actions;

            public Collector()
            {
                actions = new();
            }


            public void Collect(uint command, Action<object?> action)
            {
                actions.Add((command, action));
            }


            public IEnumerator<(uint, Action<object?>)> GetEnumerator()
            {
                return actions.GetEnumerator();
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
