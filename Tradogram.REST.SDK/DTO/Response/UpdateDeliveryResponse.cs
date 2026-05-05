using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class UpdateDeliveryResponse
    {
        public UpdateDeliveryResponseData Response { get; set; } = new UpdateDeliveryResponseData();
    }

    public class UpdateDeliveryResponseData : BaseResponse
    {
        public List<Delivery> data { get; set; } = new List<Delivery>();
    }
}
