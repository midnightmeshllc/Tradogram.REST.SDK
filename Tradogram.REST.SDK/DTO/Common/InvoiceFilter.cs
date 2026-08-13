
namespace Tradogram.REST.SDK.DTO.Common
{
    public class InvoiceFilter : BaseFilter
    {
        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all items will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// Any valid branch name. Many can be passed in comma separated list.
        /// </summary>
        public string? BuyerBranchName { get; set; }
        public FetchTypes FetchType { get; set; } = FetchTypes.Unflagged;
        public bool UpdateFetchFlag { get; set; } = false;

        /// <summary>
        /// Default is all possible statuses except "Not Sent". Possible values are "Pending Approval", "Declined", "Approved for Payment", "Paid", "New" or "Approval Rejected". 
        /// Multiple values should be comma separated. If not provided, it will default to all statuses.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Valid values are: Issued, In Delivery, Fully Received, Closed or Cancelled.
        /// </summary>
        public string? PoStatus { get; set; }

        /// <summary>
        /// Valid values are: PO Invoice or Non-PO Invoice
        /// </summary>
        public string? InvoiceType { get; set; }
    }
}
