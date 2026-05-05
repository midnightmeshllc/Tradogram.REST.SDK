using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetRequisitionResponse
    {
        public List<Requisition> Requisitions { get; set; } = new List<Requisition>();
    }

    public class Requisition
    {
        public string RequisitionCode { get; set; } = string.Empty;
        public string RequisitionName { get; set; } = string.Empty;
        public string RequisitionNumber { get; set; } = string.Empty;
        public string RequisitionStatus { get; set; } = string.Empty;
        public string DateSent { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;
        public string DateApproved { get; set; } = string.Empty;
        public string DateClosed { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
        public string RequisitionerName { get; set; } = string.Empty;
        public string RequisitionerEmail { get; set; } = string.Empty;
        public string BuyerBranchName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentNumber { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string DistributionLocationName { get; set; } = string.Empty;
        public string DistributionAddress { get; set; } = string.Empty;
        public string DistributionAddressInfo { get; set; } = string.Empty;
        public string DistributionAddressCity { get; set; } = string.Empty;
        public string DistributionAddressState { get; set; } = string.Empty;
        public string DistributionAddressZip { get; set; } = string.Empty;
        public string DistributionAddressCountry { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Subtotal { get; set; } = string.Empty;
        public string DiscountTotal { get; set; } = string.Empty;
        public List<TaxRecord> Taxes { get; set; } = new List<TaxRecord>();
        public string TaxTotal { get; set; } = string.Empty;
        public string FeesTotal { get; set; } = string.Empty;
        public string Total { get; set; } = string.Empty;
        public string HiddenCosts { get; set; } = string.Empty;
        public List<RequisitionLineItem> LineItems { get; set; } = new List<RequisitionLineItem>();
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public bool HasAttachments { get; set; } = false;
        public List<ActivityLog> ActivityLog { get; set; } = new List<ActivityLog>();
    }

    public class RequisitionLineItem
    {
        public int LineItemIndex { get; set; }
        public string LineItemCode { get; set; } = string.Empty;
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
        public string SupplierCode { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
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
        public List<LineItemCategory> Categories { get; set; } = new List<LineItemCategory>();
    }
}
