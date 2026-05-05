namespace Tradogram.REST.SDK.DTO.Request
{
    public class UpdateInvoiceUnpaidRequest
    {
        public List<MarkUnpaidInvoice> data { get; set; } = new List<MarkUnpaidInvoice>();
    }

    public class MarkUnpaidInvoice
    {
        public string InvoiceCode { get; set; } = string.Empty;
    }
}
