using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Request
{
    public class UpdateCreditNoteRequest
    {
        public List<CustomField>? CustomFields { get; set; } = new List<CustomField>();
    }
}
