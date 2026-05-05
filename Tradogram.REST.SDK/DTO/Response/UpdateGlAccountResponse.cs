using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class UpdateGlAccountResponse
    {
        public UpdateGlAccountResponseData Response { get; set; } = new();
    }

    public class UpdateGlAccountResponseData : BaseResponse
    {
        public List<GlAccount> data { get; set; } = new();
    }
}
