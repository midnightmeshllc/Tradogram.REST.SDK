
namespace Tradogram.REST.SDK.DTO.Common
{
    public class ProjectFilter : BaseFilter
    {
        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all suppliers will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// Controls whether or not to filter projects based on their active status. If set to true, only active projects will be returned; if false, all projects will be returned regardless of their status. Default value is false.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
