using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetCreditNoteResponse
    {
        public List<CreditNote> CreditNotes { get; set; } = new List<CreditNote>();
    }

    public class CreditNote
    {
        public string CreditNoteCode { get; set; } = string.Empty;
        public string CreditNoteNumber { get; set; } = string.Empty;
        public string CreditNoteDate { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string InvoiceCode { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string InvoiceReferenceNumber { get; set; } = string.Empty;
        public string InvoiceStatus { get; set; } = string.Empty;
        public string BuyerBranchName { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Subtotal { get; set; } = string.Empty;
        public string DiscountTotal { get; set; } = string.Empty;
        public List<TaxRecord> Taxes { get; set; } = new List<TaxRecord>();
        public string TaxTotal { get; set; } = string.Empty;
        public string FeesTotal { get; set; } = string.Empty;
        public string CreditNoteTotal { get; set; } = string.Empty;
        public string InvoiceTotal { get; set; } = string.Empty;
        public List<CreditNoteLineItem> LineItems { get; set; } = new List<CreditNoteLineItem>();
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public bool HasAttachments { get; set; } = false;
    }

    public class CreditNoteLineItem
    {
        public int LineItemIndex { get; set; }
        public string InvoicedLineItemCode { get; set; } = string.Empty; //new
        public string ItemNumber { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string ItemDescription { get; set; } = string.Empty;
        public string UOMLabel { get; set; } = string.Empty;
        public string UOMUnit { get; set; } = string.Empty;
        public string UOMAmount { get; set; } = string.Empty;
        public string UnitPrice { get; set; } = string.Empty;
        public string InvoicedQty { get; set; } = string.Empty;
        public string InvoicedAmount { get; set; } = string.Empty;
        public string QtyToRefund { get; set; } = string.Empty;
        public string AdjustmentAmount { get; set; } = string.Empty;
        public string ItemCreditSubtotal { get; set; } = string.Empty;
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
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public List<LineItemProject> Projects { get; set; } = new List<LineItemProject>();
        public List<LineItemDepartment> Departments { get; set; } = new List<LineItemDepartment>();
    }
}
