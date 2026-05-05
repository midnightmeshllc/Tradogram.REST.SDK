namespace Tradogram.REST.SDK.DTO.Common
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, string>? Errors { get; set; } = null;
    }

}
