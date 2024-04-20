using LUP.Graphics;

namespace LUP.Rendering.Materials
{
    public abstract class MaterialParameter
    {
        public abstract MaterialKey Key { get; }
    }

    public class MaterialParameter<T> : MaterialParameter where T : struct
    {
        public T Default { get; }

        public override MaterialKey Key { get; }

        public MaterialParameter(T value, MaterialKey key)
        {
            Default = value;
            Key = key;
        }
    }

    public class MaterialTextureParamter : MaterialParameter
    {
        public GraphicsResource? Default { get; }

        public override MaterialKey Key { get; }

        public MaterialTextureParamter(GraphicsResource texture, MaterialKey key)
        {
            Default = texture;
            Key = key;
        }
    }
}