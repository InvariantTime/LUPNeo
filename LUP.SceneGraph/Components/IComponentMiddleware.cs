﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Components
{
    public class ComponentContext
    {
        public ComponentBase? Component { get; set; }

        public bool DestroingObject { get; set; } = false;

        public required SceneObject Owner { get; init; }
    }

    public interface IComponentMiddleware
    {
        ComponentOperations Operation { get; }

        int Priority { get; }

        void Execute(ComponentContext context, Action<ComponentContext> next);
    }
}
