using LUP.Rendering.Lighting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering
{
    public class RenderCompositor : IRenderVisitor, IRenderCompositor
    {
        private const int objectCapacity = 32;
        private const int lightCapacity = 16;

        private readonly List<RenderObject> objects;
        private readonly List<ILight> lights;

        public IReadOnlyCollection<RenderObject> Objects { get; }

        public IReadOnlyCollection<ILight> Lights { get; }

        public RenderCompositor()
        {
            objects = new(objectCapacity);
            lights = new(lightCapacity);

            Objects = new ReadOnlyCollection<RenderObject>(objects);
            Lights = new ReadOnlyCollection<ILight>(lights);
        }


        public void Visit(RenderObject @object)
        {
            if (@object == null)
                throw new ArgumentNullException(nameof(@object));

            objects.Add(@object);
        }


        public void Visit(ILight light)
        {
            lights.Add(light);
        }
 
        
        public void VisitMany(IEnumerable<RenderObject> objects)
        {
            if (objects == null)
                throw new ArgumentNullException(nameof(objects));

            this.objects.AddRange(objects);
        }


        public void VisitMany(IEnumerable<ILight> lights)
        {
            if (lights == null)
                throw new ArgumentNullException(nameof(lights));

            this.lights.AddRange(lights);
        }


        public void Clear()
        {
            objects.Clear();
            lights.Clear();
        }
    }
}
