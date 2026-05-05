namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetProjectResponse
    {
        public List<Project> Projects { get; set; } = new List<Project>();
    }

    public class Project
    {
        public string ProjectCode { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
        public List<ProjectLine> ProjectLines { get; set; } = new List<ProjectLine>();
    }

    public class ProjectLine
    {
        public string ProjectLineCode { get; set; } = string.Empty;
        public string ProjectLineName { get; set; } = string.Empty;
        public string ProjectLineNumber { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
    }
}
