using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetApprovalMatrixResponse
    {
        public string TransactionCode { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public List<ApproverRecord> Approvers { get; set; } = new List<ApproverRecord>();
    }
}
