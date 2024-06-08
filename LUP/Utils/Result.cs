
namespace LUP.Utils
{
    public readonly struct Result : IResult
    {
        private static readonly Result success = new()
        {
            IsSuccess = true
        };

        public bool IsSuccess { get; init; }

        public string Error { get; init; }

        public static Result Failure(string error)
        {
            return new()
            {
                Error = error,
                IsSuccess  = false
            };
        }

        
        public static Result<T> Failure<T>(string error)
        {
            return new()
            {
                Error = error,
                IsSuccess = false
            };
        }


        public static Result Success()
        {
            return success;
        }


        public static Result<T> Success<T>(T value)
        {
            return new()
            {
                Value = value,
                IsSuccess = true
            };
        }
    }
}