using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.DTO.Common
{
    public class CustomField
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Label { get; set; } = string.Empty;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        ///<summary>Passing an empty string will erase existing value. Excluded from JSON if empty string</summary>
        public string Value { get; set; } = string.Empty;
    }
}
