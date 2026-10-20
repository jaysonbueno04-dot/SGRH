namespace SGRH.Domain.Result
{
    public class OperationResult
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public object? Data { get; set; }

        public static OperationResult Ok(string? message = null, object? data = null)
            => new() { Success = true, Message = message, Data = data };

        public static OperationResult Fail(string message)
            => new() { Success = false, Message = message };
    }
}
