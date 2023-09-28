using System.Collections.ObjectModel;

namespace LUP.SceneGraph.Descriptors
{
    public interface ISceneDescriptor
    {
        string Name { get; }

        void Visit(IScene scene);
    }


    public sealed class SceneDescriptor : ISceneDescriptor
    {
        private readonly List<ISceneObjectDescriptor> objects;

        public string Name { get; private set; }

        public IReadOnlyCollection<ISceneObjectDescriptor> Objects { get; }

        public SceneDescriptor(string name)
        {
            if (string.IsNullOrEmpty(name) == true)
                throw new Exception("Incorrect name");

            Name = name;

            objects = new();
            Objects = new ReadOnlyCollection<ISceneObjectDescriptor>(objects);
        }


        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name) == true)
                throw new Exception("Incorrect name");

            Name = name;
        }


        public void AddObject(ISceneObjectDescriptor descriptor)
        {
            if (descriptor == null)
                return;

            if (objects.Contains(descriptor) == true)
                return;

            objects.Add(descriptor);
        }


        public void RemoveObject(ISceneObjectDescriptor descriptor)
        {
            objects.Remove(descriptor);
        }


        public void Visit(IScene scene)
        {
            foreach (var obj in objects)
                scene.Instantiate(obj);
        }
    }
}