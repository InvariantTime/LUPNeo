using LUP.Graphics.Enums;
using System.Collections.Immutable;

namespace LUP.Graphics
{
    public sealed class EffectDescriptor
    {
        public ImmutableArray<ShaderData> Datas { get; }

        public EffectDescriptor(params ShaderData[] datas) : this(datas.AsEnumerable())
        {
        }


        public EffectDescriptor(IEnumerable<ShaderData> datas)
        {
            Datas = datas.ToImmutableArray();
        }
    }


    public sealed record ShaderData(ShaderTypes Type, string Source);
}
