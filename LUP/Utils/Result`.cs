
namespace LUP.Utils
{
    public readonly struct Result<T> : IResult, IResult<T>
    {
        public bool IsSuccess { get; init; }

        public T? Value { get; init; }

        public string Error { get; init; }
    }
}
