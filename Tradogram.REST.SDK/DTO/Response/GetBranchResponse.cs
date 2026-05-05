namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetBranchResponse
    {
        public List<Branch> Branches { get; set; } = new List<Branch>();
    }

    public class Branch
    {
        public string BranchCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
    }
}
