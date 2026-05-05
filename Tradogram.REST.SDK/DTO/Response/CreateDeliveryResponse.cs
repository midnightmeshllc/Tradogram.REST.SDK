using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class CreateDeliveryResponse
    {
        public CreateDeliveryResponseData Response { get; set; } = new CreateDeliveryResponseData();
    }

    public class CreateDeliveryResponseData : BaseResponse
    {
        public List<Delivery> data { get; set; } = new List<Delivery>();
    }
}
