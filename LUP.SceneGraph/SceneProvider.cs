﻿using LUP.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph
{
    public sealed record SceneProvider(IServiceScope Scope, IScene Scene);
}