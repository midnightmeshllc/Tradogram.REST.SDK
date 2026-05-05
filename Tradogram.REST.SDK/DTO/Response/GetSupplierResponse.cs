using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetSupplierResponse
    {
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }

    public class Supplier
    {
        public string SupplierCode { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
        public string GLAccountName { get; set; } = string.Empty;
        public string GLAccountNumber { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string SupplierType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FaxNumber { get; set; } = string.Empty;
        public string PostalAddressInfo { get; set; } = string.Empty;
        public string PostalAddressCity { get; set; } = string.Empty;
        public string PostalAddressState { get; set; } = string.Empty;
        public string PostalAddressZip { get; set; } = string.Empty;
        public string PostalAddressCountry { get; set; } = string.Empty;
        public string PhysicalAddressInfo { get; set; } = string.Empty;
        public string PhysicalAddressCity { get; set; } = string.Empty;
        public string PhysicalAddressState { get; set; } = string.Empty;
        public string PhysicalAddressZip { get; set; } = string.Empty;
        public string PhysicalAddressCountry { get; set; } = string.Empty;
        public string DefaultCurrency { get; set; } = string.Empty;
        public string DefaultPaymentTerms { get; set; } = string.Empty;
        public string DefaultTaxName { get; set; } = string.Empty;
        public string DefaultTaxPercentage { get; set; } = string.Empty;
        public string DefaultUseTaxName { get; set; } = string.Empty;
        public string DefaultUseTaxPercentage { get; set; } = string.Empty;
        public string TaxID { get; set; } = string.Empty;
        public string BankAccountNumber { get; set; } = string.Empty;
        public string FinancialYearEndDate { get; set; } = string.Empty;
        public string SwiftCode { get; set; } = string.Empty;
        public string BankRoutingNumber { get; set; } = string.Empty;
        public string BankCountry { get; set; } = string.Empty;
        public string BankAddress { get; set; } = string.Empty;
        public string BankCity { get; set; } = string.Empty;
        public string BankState { get; set; } = string.Empty;
        public string BankZip { get; set; } = string.Empty;
        public string InternalNotes { get; set; } = string.Empty;
        public List<SupplierContact> SupplierContacts { get; set; } = new List<SupplierContact>();
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public List<SupplierCategory> Categories { get; set; } = new List<SupplierCategory>();
        public List<SupplierBranch> SupplierBranches { get; set; } = new List<SupplierBranch>();
        public bool HasAttachments { get; set; } = false;
    }

    public class SupplierContact
    {
        public string SupplierContactCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
    }

    public class SupplierCategory : LineItemCategory
    {
        public string ParentCategoryCode { get; set; } = string.Empty;
        public string ParentCategoryName { get; set; } = string.Empty;
    }

    public class SupplierBranch
    {
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
    }
}
