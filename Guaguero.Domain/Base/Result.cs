
namespace Guaguero.Domain.Base
{
    public class Result<T> 
    {
        public T Data { get; set; }
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }

        private Result(T data, string message, bool isSuccess)
        {
            Data = data;
            Message = message;
            IsSuccessful = isSuccess;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data, null, true);
        }

        public static Result<T> Fail(string message)
        {
            return new Result<T>(null,message, false);
        }

    }
}
