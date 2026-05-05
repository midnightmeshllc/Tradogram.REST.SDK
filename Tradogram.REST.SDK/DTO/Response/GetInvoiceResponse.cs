using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetInvoiceResponse
    {
        public List<Invoice> Bills { get; set; } = new List<Invoice>();
    }

    public class Invoice
    {
        public string InvoiceCode { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomNumber { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        public string InvoiceStatus { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string ProjectNumber { get; set; } = string.Empty;
        public string POCode { get; set; } = string.Empty;
        public string PONumber { get; set; } = string.Empty;
        public string POName { get; set; } = string.Empty;
        public string BuyerBranchName { get; set; } = string.Empty;
        public string Terms { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string SupplierCode { get; set; } = string.Empty;
        public string SupplierAccountNumber { get; set; } = string.Empty;
        public string SupplierAddress { get; set; } = string.Empty;
        public string SupplierAddressInfo { get; set; } = string.Empty;
        public string SupplierAddressCity { get; set; } = string.Empty;
        public string SupplierAddressState { get; set; } = string.Empty;
        public string SupplierAddressZip { get; set; } = string.Empty;
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
        public List<InvoiceLineItem> LineItems { get; set; } = new List<InvoiceLineItem>();
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public string CreditNotesTotal { get; set; } = string.Empty; //new
        public List<CreditNoteRecord> CreditNotes { get; set; } = new List<CreditNoteRecord>(); // new
        public bool HasAttachments { get; set; } = false;
        public List<InvoiceDelivery> Deliveries { get; set; } = new List<InvoiceDelivery>(); //new
        public List<ActivityLog> ActivityLog { get; set; } = new List<ActivityLog>();

    }

    public class InvoiceDelivery
    {
        public string DeliveryCode { get; set; } = string.Empty;
    }

    public class CreditNoteRecord
    {
        public string CreditNoteCode { get; set; } = string.Empty;
        public string CreditNoteTotal { get; set; } = string.Empty;
    }

    public class InvoiceLineItem
    {
        public int LineItemIndex { get; set; }
        public string LineItemCode { get; set; } = string.Empty;
        public string POLineItemCode { get; set; } = string.Empty; //new
        public string OriginalItemCode { get; set; } = string.Empty;
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
        //public string DeliveryLocationCode { get; set; } = string.Empty; //new
        //public string DeliveryLocationName { get; set; } = string.Empty; //new
        //public string DeliveryAddress { get; set; } = string.Empty; //new
        public string ItemNumber { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string ItemDescription { get; set; } = string.Empty;
        public string UOMLabel { get; set; } = string.Empty;
        public string UOMAmount { get; set; } = string.Empty;
        public string UOMUnit { get; set; } = string.Empty;
        public string Qty { get; set; } = string.Empty;
        public string UnitPrice { get; set; } = string.Empty;
        public string ItemSubTotal { get; set; } = string.Empty;
        //public string DeliveryDate { get; set; } = string.Empty;
        public string ItemTaxName { get; set; } = string.Empty;
        public string ItemTaxRate { get; set; } = string.Empty;
        public string ItemTaxTotal { get; set; } = string.Empty;
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public List<LineItemProject> Projects { get; set; } = new List<LineItemProject>();
        public List<LineItemDepartment> Departments { get; set; } = new List<LineItemDepartment>();
    }
}
