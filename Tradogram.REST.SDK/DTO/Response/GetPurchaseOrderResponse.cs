using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetPurchaseOrderResponse
    {
        public List<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
    }

    public class PurchaseOrder
    {
        public string POCode { get; set; } = string.Empty;
        public string POName { get; set; } = string.Empty;
        public string PONumber { get; set; } = string.Empty;
        public string POStatus { get; set; } = string.Empty;
        public string DateApproved { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;
        public string DateAccepted { get; set; } = string.Empty;
        public string DateSent { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string ProjectNumber { get; set; } = string.Empty;
        public string BuyerBranchName { get; set; } = string.Empty;
        public string Terms { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string SupplierCode { get; set; } = string.Empty;
        public string SupplierAccountNumber { get; set; } = string.Empty;
        public string SupplierAddress { get; set; } = string.Empty;
        public string SupplierAddressInfo { get; set; } = string.Empty;
        public string SupplierAddressCity { get; set; } = string.Empty;
        public string SupplierAddressState { get; set; } = string.Empty;
        public string SupplierAddressZipCode { get; set;} = string.Empty;
        public string SupplierAddressCountry { get; set; } = string.Empty;
        public string SupplierContactName { get; set; } = string.Empty;
        public string SupplierContactEmail { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Subtotal { get; set; } = string.Empty;
        public string DiscountTotal { get; set; } = string.Empty;
        public List<TaxRecord> Taxes { get; set; } = new List<TaxRecord>();
        public string TaxTotal { get; set; } = string.Empty;
        public string FeesTotal { get; set; } = string.Empty;
        public string Total { get; set; } = string.Empty;
        public string HiddenCosts { get; set; } = string.Empty;
        public string DeliveryDate { get; set; } = string.Empty;
        public List<PurchaseOrderLineItem> LineItems { get; set; } = new List<PurchaseOrderLineItem>();
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public bool HasAttachments { get; set; } = false;
        public List<ActivityLog> ActivityLog { get; set; } = new List<ActivityLog>();

    }

    public class PurchaseOrderLineItem
    {
        public int LineItemIndex { get; set; }
        public string LineItemCode { get; set; } = string.Empty;
        public string OriginalItemCode { get; set; } = string.Empty; //new
        public bool IsStockItem { get; set; } = false; //new
        public string ProjectCode { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectNumber { get; set; } = string.Empty;
        public string ProjectLineCode { get; set; } = string.Empty;
        public string ProjectLineName { get; set; } = string.Empty;
        public string ProjectLineNumber { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentNumber { get; set; } = string.Empty;
        public string GLAccountName { get; set; } = string.Empty;
        public string GLAccountNumber { get; set; } = string.Empty;
        public string DeliveryLocationCode { get; set; } = string.Empty; //new
        public string DeliveryLocationName { get; set; } = string.Empty; //new
        public string DeliveryAddress { get; set; } = string.Empty; //new
        public string ItemNumber { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string ItemDescription { get; set; } = string.Empty;
        public string UOMLabel { get; set; } = string.Empty;
        public string UOMAmount { get; set; } = string.Empty;
        public string UOMUnit { get; set; } = string.Empty;
        public string Qty { get; set; } = string.Empty;
        public string UnitPrice { get; set; } = string.Empty;
        public string ItemSubTotal { get; set; } = string.Empty;
        public string DeliveryDate { get; set; } = string.Empty;
        public string ItemTaxName { get; set; } = string.Empty;
        public string ItemTaxRate { get; set; } = string.Empty;
        public string ItemTaxTotal { get; set; } = string.Empty;
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public List<LineItemProject> Projects { get; set; } = new List<LineItemProject>();
        public List<LineItemDepartment> Departments { get; set; } = new List<LineItemDepartment>();
    }
}
