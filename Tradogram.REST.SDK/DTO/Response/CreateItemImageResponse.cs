using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class CreateItemImageResponse
    {
        public CreateItemImageResponseData Response { get; set; } = new CreateItemImageResponseData();
    }

    public class CreateItemImageResponseData : BaseResponse
    {
    }
}
