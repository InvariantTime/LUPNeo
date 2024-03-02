using LUP.Graphics.Enums;

namespace LUP.Graphics
{
    public readonly struct DrawData
    {
        public PrimitiveTypes Primitive { get; init; }
        
        public bool IsIndixed { get; init; }

        public int First { get; init; }

        public int Count { get; init; }
    }

    public struct DrawInstanceData
    {
        public DrawData Data { get; init; }

        public int Count { get; set; }

        public DrawInstanceData(DrawData data)
        {
            Data = data;
            Count = 1;
        }
    }
}
