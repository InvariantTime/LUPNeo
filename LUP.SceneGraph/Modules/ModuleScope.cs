﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Modules
{
    public class ModuleScope : IModuleScope
    {
        private readonly ImmutableList<SceneModule> modules;

        public int Count => modules.Count;

        public ModuleScope(IEnumerable<SceneModule> modules)
        {
            this.modules = modules.ToImmutableList();
        }


        public IEnumerator<SceneModule> GetEnumerator()
        {
            return modules.GetEnumerator();
        }


        public T? GetModule<T>() where T : SceneModule
        {
            return (T?)modules.Find(x => x is T);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return modules.GetEnumerator();
        }
    }
}
