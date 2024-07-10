using LUP.SceneGraph.Modules;
using System.Collections;
using System.Collections.Immutable;

namespace LUP.SceneGraph.Implementation
{
    sealed class SceneModuleScope : ISceneModuleScope
    {
        private readonly ImmutableArray<ISceneModule> _modules;

        public SceneModuleScope(IEnumerable<ISceneModule> modules)
        {
            _modules = modules.ToImmutableArray();
        }

        public IEnumerator<ISceneModule> GetEnumerator()
        {
            return _modules.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}