using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class UpdateCreditNoteResponse
    {
        public UpdateCreditNoteResponseData Response { get; set; } = new UpdateCreditNoteResponseData();
    }

    public class UpdateCreditNoteResponseData : BaseResponse
    {
        public List<CreditNote> data { get; set; } = new List<CreditNote>();
    }
}
