﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection.CallSites
{
    public abstract class Callsite
    {
        public required Type Alias { get; init; }

        public required ServiceDescriptor? Root { get; init; }
    }
}