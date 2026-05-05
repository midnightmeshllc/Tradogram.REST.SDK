using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class CreateDepartmentResponse
    {
        public CreateDepartmentResponseData Response { get; set; } = new CreateDepartmentResponseData();
    }

    public class CreateDepartmentResponseData : BaseResponse
    {
        public List<Department> data { get; set; } = new List<Department>();
    }
}
