using Tradogram.REST.SDK.DTO.Common;
using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.DTO.Request
{
    public class UpdateInvoiceRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CustomField>? CustomFields { get; set; } = new List<CustomField>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<UpdateInvoiceLineItem>? LineItems { get; set; } = new List<UpdateInvoiceLineItem>();
    }

    public class UpdateInvoiceLineItem
    {
        public required string LineItemCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CustomField>? CustomFields { get; set; } = new List<CustomField>();
    }
}
