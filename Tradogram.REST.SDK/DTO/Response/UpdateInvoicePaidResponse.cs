using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class UpdateInvoicePaidResponse
    {
        public List<MarkInvoicePaidResponse> Bills { get; set; } = new List<MarkInvoicePaidResponse>();
    }

    public class MarkInvoicePaidResponse
    {
        public string InvoiceCode { get; set; } = string.Empty;
        public MarkInvoicePaidResponseData Response { get; set; } = new MarkInvoicePaidResponseData();

    }

    public class MarkInvoicePaidResponseData : BaseResponse
    {
        public string Action { get; set; } = string.Empty;
    }
}
