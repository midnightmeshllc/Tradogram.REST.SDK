using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class UpdateDepartmentResponse
    {
        public UpdateDepartmentResponseData Response { get; set; } = new UpdateDepartmentResponseData();
    }

    public class UpdateDepartmentResponseData : BaseResponse
    {
        public List<Department> data { get; set; } = new List<Department>();
    }
}
