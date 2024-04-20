using LUP.Rendering.Effects.Generation;
using System.Collections.Immutable;

namespace LUP.Rendering.Materials.Sources
{
    public readonly struct MaterialMethod
    {
        public string Name { get; }

        public ImmutableArray<ShaderParam> Args { get; }

        public string Body { get; }

        public string Return { get; }

        public MaterialMethod(string name, string body)
        {
            Name = name;
            Body = body;
            Return = string.Empty;
            Args = ImmutableArray<ShaderParam>.Empty;
        }


        public MaterialMethod(string name, string body, string @return, params ShaderParam[] @params) 
            : this(name, body, @return, @params.AsEnumerable())
        {
        }


        public MaterialMethod(string name, string body, string @return, IEnumerable<ShaderParam> args)
        {
            Name = name;
            Body = body;
            Return = @return;
            Args = args is ImmutableArray<ShaderParam> arr ? arr : args.ToImmutableArray();
        }


        public MaterialMethod Rewrite(string? body)
        {
            if (body == null)
                return this;

            return new(Name, body, Return, Args);
        }
    }
}
