
namespace Tradogram.REST.SDK.DTO.Common
{
    public class PurchaseOrderFilter : BaseFilter
    {
        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all suppliers will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// Default is all possible statuses. Possible values are "Pending Approval", "Approval Rejected", "Pending Supplier", "Declined by Supplier", "Issued", "In Delivery", "Fully Received", "Closed", "Cancelled", "New Qoute", "Declined Qoute", "Waiting for Confirmation". 
        /// Multiple values should be comma separated. If not provided, it will default to all statuses.
        /// </summary>
        public string Status { get; set; } = "Pending Approval, Approval Rejected, Pending Supplier, Declined by Supplier, Issued, In Delivery, Fully Received, Closed, Cancelled, New Qoute, Declined Qoute, Witing for Confirmation";
        
        public FetchTypes FetchType { get; set; } = FetchTypes.Unflagged;
        public bool UpdateFetchFlag { get; set; } = false;
        public string? BuyerBranchName { get; set; } = null;

    }
}
