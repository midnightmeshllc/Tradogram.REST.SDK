namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetLocationResponse
    {
        public List<Location> Locations { get; set; } = new List<Location>();
    }

    public class Location
    {
        public string LocationCode { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string AddressInfo { get; set; } = string.Empty;
        public string AddressCity { get; set; } = string.Empty;
        public string AddressState { get; set; } = string.Empty;
        public string AddressZip { get; set; } = string.Empty;
        public string AddressCountry { get; set; } = string.Empty;
        public bool IsDelivery { get; set; } = false;
        public bool IsDefaultDelivery { get; set; } = false;
        public bool IsPublic { get; set; } = false;
        public bool IsDistribution { get; set; } = false;
        public bool IsBilling { get; set; } = false;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
    }
}
