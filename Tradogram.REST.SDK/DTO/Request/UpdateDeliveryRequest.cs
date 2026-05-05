using Tradogram.REST.SDK.DTO.Common;
using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.DTO.Request
{
    public class UpdateDeliveryRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DeliveredVia { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BillNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string InvoiceNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ShippedDate { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ArrivalDate { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ReceiveDate { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Notes { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<UpdateDeliveryItem>? DeliveryItems { get; set; } = new List<UpdateDeliveryItem>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CustomField>? CustomFields { get; set; } = new List<CustomField>();
    }

    public class UpdateDeliveryItem
    {
        /// <summary>Use GET POs endpoint for corresponding PO LineItemCode for which you wish to add the delivery note.</summary>
        public required string POLineItemCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal QtyShipped { get; set; } = decimal.Zero;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal QtyReceived { get; set; } = decimal.Zero;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Notes { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CustomField>? CustomFields { get; set; } = new List<CustomField>();
    }
}
