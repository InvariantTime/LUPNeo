
namespace LUP.Utils
{
    public interface IResult
    {
        bool IsSuccess { get; }

        string? Error { get; }
    }

    public interface IResult<T>
    {
        T? Value { get; }
    }
}
