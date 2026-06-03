

namespace Tradogram.REST.SDK.DTO.Common
{
    public class SupplierFilter : BaseFilter
    {
        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all suppliers will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;
        /// <summary>
        /// Default value is "Pending Approval, Active, Inactive". Possible values are "Pending Approval", "Active", "Inactive". 
        /// Multiple values should be comma separated. If not provided, it will default to all three statuses.
        /// </summary>
        public string? Status { get; set; } = "Pending Approval, Active, Inactive";

        /// <summary>
        /// Any valid Branch Name. If not provided, it will default to null and suppliers from all branches will be returned.
        /// </summary>
        public string? BranchName { get; set; } = null;
    }
}
