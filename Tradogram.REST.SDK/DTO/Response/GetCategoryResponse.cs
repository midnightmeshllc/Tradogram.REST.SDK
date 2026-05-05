namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetCategoryResponse
    {
        public List<Category> Categories { get; set; } = new List<Category>();
    }

    public class Category
    {
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string ParentCategoryCode { get; set; } = string.Empty;
        public string ParentCategoryName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public bool IsCompanyWide { get; set; } = false;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
    }
}
