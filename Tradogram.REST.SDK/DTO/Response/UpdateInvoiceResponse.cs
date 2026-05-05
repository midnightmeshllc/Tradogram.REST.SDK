using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class UpdateInvoiceResponse
    {
        public UpdateInvoiceResponseData Response { get; set; } = new UpdateInvoiceResponseData();
    }

    public class UpdateInvoiceResponseData : BaseResponse
    {
        public List<Invoice> data { get; set; } = new List<Invoice>();
    }
}
