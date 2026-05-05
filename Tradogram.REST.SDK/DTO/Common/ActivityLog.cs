namespace Tradogram.REST.SDK.DTO.Common
{
    public class ActivityLog
    {
        public string DateTime { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Activity { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
