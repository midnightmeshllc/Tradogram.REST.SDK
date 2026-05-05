using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class CreateGlAccountResponse
    {
        public CreateGlAccountResponseData Response { get; set; } = new CreateGlAccountResponseData();
    }

    public class CreateGlAccountResponseData : BaseResponse
    {
        public List<GlAccount> data { get; set; } = new List<GlAccount>();
    }
}
