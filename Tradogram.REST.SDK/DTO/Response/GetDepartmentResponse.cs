namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetDepartmentResponse
    {
        public List<Department> Departments { get; set; } = new List<Department>();
    }

    public class Department
    {
        public string DepartmentCode { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentNumber { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
        public List<string> DepartmentGLAccounts { get; set; } = new List<string>();
    }
}
