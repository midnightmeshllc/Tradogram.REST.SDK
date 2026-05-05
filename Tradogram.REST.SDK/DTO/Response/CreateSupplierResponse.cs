using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class CreateSupplierResponse
    {
        public CreateSupplierResponseData Response { get; set; } = new CreateSupplierResponseData();
    }

    public class CreateSupplierResponseData : BaseResponse
    {
        public List<Supplier> data { get; set; } = new List<Supplier>();
    }
}




