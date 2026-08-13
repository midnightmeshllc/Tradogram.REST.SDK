
namespace Tradogram.REST.SDK.DTO.Common
{
    public class GlAccountFilter : BaseFilter
    {
        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all items will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// Controls whether the filter retrieves only active GL Accounts or all GL Accounts. If set to true, only active GL Accounts will be retrieved; if false, all GL Accounts will be retrieved. Default value is true.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
