using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;
using LUP.SceneGraph.Scenes;
using System.Collections.Concurrent;

namespace LUP.SceneGraph.Implementation
{
    sealed class ObjectDestructor
    {
        private readonly SceneCollection _objects;

        public ObjectDestructor(SceneCollection objects)
        {
            _objects = objects;
        }

        public bool Destruct(SceneObject @object)
        {
            var stack = new Stack<SceneObject>();
            stack.Push(@object);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (_objects.RemoveInternal(current.Id) == false)
                    return false;

                current.Components.Uninitialize();

                var children = _objects.Where(x => x.IsChildOf(current));

                foreach (var child in children)
                    stack.Push(child);
            }

            return true;
        }
    }
}