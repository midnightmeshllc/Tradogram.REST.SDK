using Tradogram.REST.SDK.DTO.Common;
using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.DTO.Request
{
    public class UpdateItemRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BranchCode { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ItemNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ItemName { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <summary>Alllowed options are Buy, Sell, or Both.</summary>
        public required string ItemType { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal PurchasePrice { get; set; } = decimal.Zero;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal SellingPrice { get; set; } = decimal.Zero;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal DefaultQuantity { get; set; } = decimal.Zero;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required string DefaultPurchaseTaxCode { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = false;

        public bool IsStockItem { get; set; } = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UOMLabel { get; set; } = string.Empty;

        /// <summary>Check GET Units for possible values.</summary>
        public required string UOMUnit { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Notes { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CustomField>? CustomFields { get; set; } = new List<CustomField>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CreateItemCategory>? Categories { get; set; } = new List<CreateItemCategory>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CreateItemSupplier>? Suppliers { get; set; } = new List<CreateItemSupplier>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CreateItemGlAccount>? GLAccounts { get; set; } = new List<CreateItemGlAccount>();
    }
}
