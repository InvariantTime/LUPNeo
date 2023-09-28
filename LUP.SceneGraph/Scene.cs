using LUP.SceneGraph.Modules;
using LUP.SceneGraph.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph
{
    sealed class Scene : DisposableObject, IScene
    {
        private IRootObjectScope? objects;
        private IModuleScope? modules;

        public bool IsInitialized { get; private set; }

        public IModuleScope GetModules()
        {
            if (IsInitialized == false)
                throw new InvalidOperationException("scene is not initialized");

            return modules!;
        }


        public IObjectScope GetObjects()
        {
            if (IsInitialized == false)
                throw new InvalidOperationException("Scene is not initialized");

            return objects!;
        }

        
        public IRootObjectScope GetRootObjects()
        {
            if (IsInitialized == false)
                throw new InvalidOperationException("Scene is not initialized");

            return objects!;
        }


        internal void Initialize(IModuleScope modules, IRootObjectScope objects)
        {
            this.modules = modules ?? throw new ArgumentNullException(nameof(modules));
            this.objects = objects ?? throw new ArgumentNullException(nameof(objects));

            IsInitialized = true;
        }


        internal void Uninitialize()
        {
        }
    }
}
