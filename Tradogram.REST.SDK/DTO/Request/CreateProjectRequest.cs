using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.DTO.Request
{
    public class CreateProjectRequest
    {
        public required string ProjectName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ProjectNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CreateProjectLine>? ProjectLines { get; set; } = new List<CreateProjectLine>();
    }

    public class CreateProjectLine
    {
        public required string ProjectLineName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ProjectLineNumber { get; set; } = string.Empty;
    }
}
