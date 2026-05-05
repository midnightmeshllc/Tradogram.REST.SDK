using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class CreateProjectResponse
    {
        public CreateProjectResponseData Response { get; set; } = new CreateProjectResponseData();
    }

    public class CreateProjectResponseData : BaseResponse
    {
        public List<Project> data { get; set; } = new List<Project>();
    }
}
