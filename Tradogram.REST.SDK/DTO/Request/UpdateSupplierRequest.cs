using Tradogram.REST.SDK.DTO.Common;
using System.Text.Json.Serialization;

namespace Tradogram.REST.SDK.DTO.Request
{
    public class UpdateSupplierRequest
    {
        public required string CompanyName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string AccountNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Website { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        /// <summary>Valid options are Operational, Strategic, Commodity or Joint Venture.</summary>
        public string SupplierType { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsActive { get; set; } = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PhoneNumber { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FaxNumber { get; set; } = string.Empty;

        public required string PostalAddressInfo { get; set; } = string.Empty;

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

        public string PhysicalAddressState { get; set; } = string.Empty;
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

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<UpdateSupplierContact> SupplierContacts { get; set; } = new();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<CustomField>? CustomFields { get; set; } = new();
    }

    public class UpdateSupplierContact : CreateSupplierContact
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        ///<summary>This is optional unless you are trying to update an existing contact.Excluding this field from your post request will make Tradogram create a whole new contact.</summary>
        public string SupplierContactCode { get; set; } = string.Empty;
    }
}
