using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class UpdateItemResponse
    {
        public UpdateItemResponseData Response { get; set; } = new UpdateItemResponseData();
    }

    public class UpdateItemResponseData : BaseResponse
    {
        public List<Item> data { get; set; } = new List<Item>();
    }
}
