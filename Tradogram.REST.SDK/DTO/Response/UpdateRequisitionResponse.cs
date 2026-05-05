using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class UpdateRequisitionResponse
    {
        public UpdateRequisitionResponseData Response { get; set; } = new UpdateRequisitionResponseData();
    }

    public class UpdateRequisitionResponseData : BaseResponse
    {
        public List<Requisition> data { get; set; } = new List<Requisition>();
    }


}
