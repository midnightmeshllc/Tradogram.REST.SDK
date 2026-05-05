namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetTaxResponse
    {
        public List<Tax> Taxes { get; set; } = new List<Tax>();
    }

    public class Tax
    {
        public string TaxCode { get; set; } = string.Empty;
        public string TaxType { get; set; } = string.Empty;
        public string TaxName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<TaxComponent> TaxComponents { get; set; } = new List<TaxComponent>();
        public string TotalTaxRate { get; set; } = string.Empty;
    }

    public class TaxComponent
    {
        public string Code { get; set; } = string.Empty;
        public string Rate { get; set; } = string.Empty;
    }
}
