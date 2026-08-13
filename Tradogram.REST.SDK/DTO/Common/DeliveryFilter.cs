
namespace Tradogram.REST.SDK.DTO.Common
{
    public class DeliveryFilter : BaseFilter
    {

        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all items will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// Defaults to include all Statuses. Possible values are "In Delivery", "Fully Received" or "Closed". 
        /// Multiple values should be comma separated. If not provided, it will default to all statuses.
        /// </summary>
        public string Status { get; set; }
        public FetchTypes FetchType { get; set; } = FetchTypes.Unflagged;
        public bool UpdateFetchFlag { get; set; } = false;

        /// <summary>
        /// Any valid branch name. Many can be passed in comma separated list.
        /// </summary>
        public string? BuyerBranchName { get; set; }
    }
}
