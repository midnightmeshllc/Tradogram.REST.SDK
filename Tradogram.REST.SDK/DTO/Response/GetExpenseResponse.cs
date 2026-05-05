using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetExpenseResponse
    {
        public List<Expense> Expenses { get; set; } = new List<Expense>();
    }

    public class Expense
    {
        public string ExpenseCode { get; set; } = string.Empty;
        public string ExpenseNumber { get; set; } = string.Empty;
        public string ExpenseTitle { get; set; } = string.Empty;
        public string ExpenseStatus { get; set; } = string.Empty;
        public string ExpenseDate { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
        public string Payee { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string BuyerBranchName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Total { get; set; } = string.Empty;
        public List<ExpenseLineItem> LineItems { get; set; } = new List<ExpenseLineItem>();
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public List<ActivityLog> ActivityLog { get; set; } = new List<ActivityLog>();
    }

    public class ExpenseLineItem
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
        public string ExpenseDescription { get; set; } = string.Empty; //new
        public string VendorName { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string TaxName { get; set; } = string.Empty;
        public string TaxAmount { get; set; } = string.Empty;
        public string SubTotal { get; set; } = string.Empty;
        public List<LineItemProject> Projects { get; set; } = new List<LineItemProject>();
        public List<LineItemDepartment> Departments { get; set; } = new List<LineItemDepartment>();

    }

}
