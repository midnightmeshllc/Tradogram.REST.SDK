
namespace Tradogram.REST.SDK.DTO.Common
{
    public class CategoryFilter : BaseFilter
    {
        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all items will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        public bool? IsCompanyWide { get; set; }
    }
}
