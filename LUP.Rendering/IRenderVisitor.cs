using LUP.Graphics;
using LUP.Rendering.Lighting;

namespace LUP.Rendering
{
    public interface IRenderVisitor
    {
        void Visit(RenderObject @object);

        void Visit(ILight light);

        void VisitMany(IEnumerable<RenderObject> objects);

        void VisitMany(IEnumerable<ILight> lights);
    }
}
