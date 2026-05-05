namespace Tradogram.REST.SDK.DTO.Request
{
    public class PaginateResultsRequest
    {
        public bool Paginate { get; set; } = false;
        public int PageSize { get; set; } = 100;
        public int Page { get; set; } = 1;
    }
}
