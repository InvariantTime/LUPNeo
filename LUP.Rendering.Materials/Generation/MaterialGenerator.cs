
using LUP.Rendering.Effects.Generation;

namespace LUP.Rendering.Materials.Generation
{
    public class MaterialGenerator : IMaterialGenerator
    {
        private readonly IRenderEffectGenerator effectGenerator;

        public MaterialGenerator(IRenderEffectGenerator generator)
        {
            this.effectGenerator = generator;
        }


        public RenderMaterial Generate(IMaterialDescriptor descriptor)
        {
            var context = new MaterialContext();
            descriptor.Generate(context);

            var parameters = context.GetParameters();

            var pass = new RenderMaterialPass(null, parameters);

            return new RenderMaterial(pass);
        }
    }
}