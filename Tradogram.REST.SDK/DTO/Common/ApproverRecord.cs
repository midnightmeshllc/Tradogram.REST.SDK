namespace Tradogram.REST.SDK.DTO.Common
{
    public class ApproverRecord
    {
        public string ApprovalCode { get; set; } = string.Empty;
        public string ApproverName { get; set; } = string.Empty;
        public int HeirarchyNumber { get; set; } = 0;
        public string Status { get; set; } = string.Empty;
        public string StatusDate { get; set; } = string.Empty;
    }
}
