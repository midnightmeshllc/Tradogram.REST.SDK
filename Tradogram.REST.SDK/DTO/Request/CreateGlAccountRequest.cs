namespace Tradogram.REST.SDK.DTO.Request
{
    public class CreateGlAccountRequest
    {
        public required string GLAccountName { get; set; } = string.Empty;
        public required string GLAccountNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
