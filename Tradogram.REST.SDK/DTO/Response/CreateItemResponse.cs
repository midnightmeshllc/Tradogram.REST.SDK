using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class CreateItemResponse
    {
        public CreateItemResponseData Response { get; set; } = new CreateItemResponseData();
    }

    public class CreateItemResponseData : BaseResponse
    {
        public List<Item> data { get; set; } = new List<Item>();
    }
}
