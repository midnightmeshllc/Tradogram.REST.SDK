
namespace Tradogram.REST.SDK.DTO.Common
{
    public class ItemFilter : BaseFilter
    {
        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all items will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// Any valid Branch Name. If not provided, it will default to null and suppliers from all branches will be returned.
        /// </summary>
        public string? BranchName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCompanyWide { get; set; }
    }
}
