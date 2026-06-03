
namespace Tradogram.REST.SDK.DTO.Common
{
    public class RequisitionFilter : BaseFilter
    {
        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all requisitions will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// Default value is "Pending Approval, Rejected, Open, Closed, Fulfilled, Cancelled". Possible values are "Pending Approval", "Rejected", "Open", "Closed", "Fulfilled", "Cancelled".
        /// Multiple values should be comma separated. If not provided, it will default to all six statuses.
        /// </summary>
        public string Status { get; set; } = "Pending Approval, Rejected, Open, Closed, Fulfilled, Cancelled";
        public FetchTypes FetchType { get; set; } = FetchTypes.Unflagged;
        public bool UpdateFetchFlag { get; set; } = false;
        public string? BuyerBranchName { get; set; } = null;

    }
}
