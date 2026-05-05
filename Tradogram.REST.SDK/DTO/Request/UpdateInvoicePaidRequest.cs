namespace Tradogram.REST.SDK.DTO.Request
{
    public class UpdateInvoicePaidRequest
    {
        public List<MarkInvoicePaid> data { get; set; } = new List<MarkInvoicePaid>();
    }
    
    public class MarkInvoicePaid
    {
        public string InvoiceCode { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
    }
}

