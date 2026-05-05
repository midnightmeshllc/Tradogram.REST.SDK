using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.DTO.Request
{
    public class UpdateDepartmentRequest
    {
        public required string BranchCode { get; set; }
        public required string DepartmentName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DepartmentNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsActive { get; set; } = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <summary>If the list is empty, the department will be associated with all GL Accounts.</summary>
        public List<string> DepartmentGLAccounts { get; set; } = new List<string>();
    }
}
