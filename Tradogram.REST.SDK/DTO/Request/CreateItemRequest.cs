using Tradogram.REST.SDK.DTO.Common;
using Tradogram.REST.SDK.DTO.Response;
using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.DTO.Request
{
    public class CreateItemRequest
    {
        public required string BranchCode { get; set; }
        public required string ItemNumber { get; set; }
        public required string ItemName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <summary>Alllowed options are Buy (default), Sell, or Both.</summary>
        public string ItemType { get; set; } = "Buy";

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <summary>Purchase Price must be greater than zero if ItemType is "Buy"</summary>
        public required decimal PurchasePrice { get; set; } = decimal.Zero;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal SellingPrice { get; set; } = decimal.Zero;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal DefaultQuantity { get; set; } = decimal.Zero;

        /// <summary>Check GET Tax endpoint for available values</summary>
        public required string DefaultPurchaseTaxCode { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = false;

        public bool IsStockItem { get; set; } = false;

        /// <summary>Unit of measure amount</summary>
        public required decimal UOMAmount { get; set; } = decimal.Zero;

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

    public class CreateItemGlAccount
    {
        public required string GLAccountCode { get; set; }
    }

    public class CreateItemSupplier
    {
        public required string SupplierCode { get; set; }
    }

    public class CreateItemCategory
    {
        public required string CategoryCode { get; set; }
    }
}
