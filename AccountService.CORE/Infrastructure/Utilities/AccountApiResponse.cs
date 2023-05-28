namespace AccountService.Domain.Infrastructure.Utilities
{
    public class AccountApiResponse<T> : IAccountApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public T Data { get; set; }

        public AccountApiResponse(bool isSuccess, string message, T data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public AccountApiResponse(bool isSuccess, T data)
        {
            IsSuccess = isSuccess;
            Data = data;
        }

        public AccountApiResponse(bool isSuccess, string message, Exception exception)
        {
            IsSuccess = isSuccess;
            Message = message;
            Exception = exception;
        }

        public AccountApiResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public AccountApiResponse(bool isSuccess, List<string> messages)
        {
            IsSuccess = isSuccess;
            Message = string.Join(",", messages);
        }

        public AccountApiResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;

        }
    }
}
