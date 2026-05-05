using Tradogram.REST.SDK.DTO.Common;
using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.DTO.Request
{
    public class CreateSupplierRequest
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        /// <summary>Code is used to hook a supplier to a company branch. Will be excluded from JSON if not explicitly set.</summary>
        public string? BranchCode { get; set; } = null;
        public required string CompanyName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string AccountNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Website { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <summary>Valid options are Operational, Strategic, Commodity or Joint Venture.</summary>
        public string SupplierType { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PhoneNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FaxNumber { get; set; } = string.Empty;
        public required string PostalAddressInfo {  get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PostalAddressCity { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PostalAddressState { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PostalAddressZip { get; set; } = string.Empty;
        public required string PostalAddressCountry { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PhysicalAddressInfo { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PhysicalAddressCity { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PhysicalAddressState { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PhysicalAddressZip { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PhysicalAddressCountry { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <summary>ISO Currency Code; eg USD, CAD, etc</summary>
        public string DefaultCurrency { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DefaultPaymentTerms { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DefaultTaxName { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        /// <summary>decimal in string format, default is "0.0"</summary>
        public string DefaultTaxPercentage { get; set; } = "0.0";

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DefaultUseTaxName { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <summary>Decimal in string format, default is "0.0"</summary>
        public string DefaultUseTaxPercentage { get; set; } = "0.0";

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TaxID { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BankAccountNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FinancialYearEndDate { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string InternalNotes { get; set; } = string.Empty;

        /// <summary>Atleast one supplier contact is required.</summary>
        public required List<CreateSupplierContact> SupplierContacts { get; set; }
        public List<CustomField>? CustomFields { get; set; } = new();

    }

    public class CreateSupplierContact
    {
        public required string Name { get; set; }
        public required string Email { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PhoneNumber { get; set;} = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Branch { get; set; } = string.Empty;
    }
}
