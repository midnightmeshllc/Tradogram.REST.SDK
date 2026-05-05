using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.DTO.Request
{
    public class UpdateProjectRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ProjectName { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ProjectNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CreateProjectLine>? ProjectLines { get; set; } = new List<CreateProjectLine>();
    }
}
