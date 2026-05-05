using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetItemResponse
    {
        public List<Item> Items { get; set; } = new List<Item>();
    }

    public class Item
    {
        public string ItemCode { get; set; } = string.Empty;
        public string ItemNumber { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string ItemType { get; set; } = string.Empty;
        public string PurchasePrice { get; set; } = string.Empty;
        public string SellingPrice { get; set; } = string.Empty;
        public string DefaultQuantity { get; set; } = string.Empty;
        public string DefaultPurchaseTaxCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public bool IsStockItem { get; set; } = false;
        public string UOMLabel { get; set; } = string.Empty;
        public string UOMAmount { get; set; } = string.Empty;
        public string UOMUnit { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public bool IsCompanyWide { get; set; } = false;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public List<LineItemCategory> Categories { get; set; } = new List<LineItemCategory>();
        public List<ItemSupplier> Suppliers { get; set; } = new List<ItemSupplier>();
        public List<ItemGlAccount> GLAccounts { get; set; } = new List<ItemGlAccount>();
        public bool HasImages { get; set; } = false;
        public bool HasAttachments { get; set; } = false;
    }

    public class ItemGlAccount
    {
        public string GLAccountCode { get; set; } = string.Empty;
        public string GLAccountName { get; set; } = string.Empty;
        public string GLAccountNumber { get; set; } = string.Empty;
    }

    public class ItemSupplier
    {
        public string SupplierCode { get; set; } = string.Empty;
        public string SupplierCompanyName { get; set; } = string.Empty;
        public string SupplierAccountNumber { get; set; } = string.Empty;
        public string ItemPrice { get; set; } = string.Empty;
        public string ItemNumber { get; set; } = string.Empty;
        public string UOMLabel { get; set; } = string.Empty;
        public string UOMAmount { get; set; } = string.Empty;
        public string UOMUnit { get; set; } = string.Empty;
    }
}
