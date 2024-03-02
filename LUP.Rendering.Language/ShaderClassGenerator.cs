using LUP.Rendering.Language.Members;

namespace LUP.Rendering.Language
{
    static class ShaderClassGenerator
    {
        public static ShaderClass Generate(ShaderClassDescriptor descriptor)
        {
            var type = new ShaderClassType(descriptor.Name, descriptor.Bases);
            var methods = GenerateMethods(descriptor);

            return new ShaderClass(methods, type); 
        }


        private static IEnumerable<IShaderMember> GenerateMethods(ShaderClassDescriptor descriptor)
        {
            var table = new ShaderMethodTable();

            foreach (var @base in descriptor.Bases)
            {
                foreach (var method in @base.GetMethods())
                {
                    table.Push(method);
                }
            }

            foreach (var method in descriptor.Members.Where(x => x is ShaderMethod)
                .Select(x => x as ShaderMethod))
            {
                if (method == null)
                    continue;

                table.Push(method);
            }

            return table.Select(x => x as IShaderMember);
        }
    }

    public readonly struct ShaderClassDescriptor
    {
        public string Name { get; init; }

        public IEnumerable<ShaderClass> Bases { get; init; }

        public IEnumerable<IShaderMember> Members { get; init; }
    }
}
