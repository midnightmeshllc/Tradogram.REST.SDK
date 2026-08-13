
namespace Tradogram.REST.SDK.DTO.Common
{
    public class UnitFilter
    {
        /// <summary>
        /// Controls whether or not to apply the filter criteria. If set to true, the filter criteria will be applied; if false, the filter criteria will be ignored and all items will be returned. Default value is false.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// No filter is applied by default. Valid values are "Length", "Weight", "Volume", "Area", "Pieces", "Time". Multiple values should be comma separated. If not provided, it will default to all unit groups.
        /// </summary>
        public string? UnitGroupName { get; set; }
    }
}
