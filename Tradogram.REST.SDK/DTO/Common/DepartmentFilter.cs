
namespace Tradogram.REST.SDK.DTO.Common
{
    public class DepartmentFilter : BaseFilter
    {
        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all items will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// Any valid branch name. Many can be passed in comma separated list.
        /// </summary>
        public string? BranchName { get; set; }

        /// <summary>
        /// Controls whether the filter retrieves only active Departments or all Departments. If set to true, only active Departments will be retrieved; if false, all Departments will be retrieved. Default value is true.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
