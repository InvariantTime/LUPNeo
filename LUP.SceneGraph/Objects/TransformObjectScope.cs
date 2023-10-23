using LUP.SceneGraph.Descriptors;
using System.Collections;

namespace LUP.SceneGraph.Objects
{
    class TransformObjectScope : IObjectScope
    {
        private readonly List<SceneObject> objects;
        private readonly SceneObject parent;
        private readonly IObjectBuilder builder;

        public int Count => objects.Count;

        public SceneObject Parent => parent;

        public TransformObjectScope(SceneObject parent, IObjectBuilder builder)
        {
            this.parent = parent;
            this.builder = builder;

            objects = new();
        }


        public SceneObject Instantiate(ISceneObjectDescriptor? descriptor)
        {
            var obj = builder.Build(this, descriptor);
            objects.Add(obj);

            return obj;
        }


        public void Remove(SceneObject @object)
        {
            bool result = objects.Remove(@object);

            if (result == true)
                @object.Uninitialize();
        }


        public IEnumerator<SceneObject> GetEnumerator()
        {
            return objects.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
