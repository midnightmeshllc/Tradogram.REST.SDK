using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class UpdateSupplierResponse
    {
        public UpdateSupplierResponseData Response { get; set; } = new UpdateSupplierResponseData();
    }

    public class UpdateSupplierResponseData : BaseResponse
    {
        public List<Supplier> data { get; set; } = new List<Supplier>();
    }
}
