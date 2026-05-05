namespace Tradogram.REST.SDK.DTO.Response
{
    public class GetGlAccountResponse
    {
        public List<GlAccount> GlAccounts { get; set; } = new List<GlAccount>();
    }

    public class GlAccount
    {
        public string GLAccountCode { get; set; } = string.Empty;
        public string GLAccountName { get; set; } = string.Empty;
        public string GLAccountNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public string CreatedDate { get; set; } = string.Empty;
        public string ModifiedDate { get; set; } = string.Empty;
    }
}
