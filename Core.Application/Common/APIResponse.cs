namespace Core.Application.Common
{
    public class APIResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public APIResponse() { }

        public APIResponse(bool success, string message, object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
