using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.DTO.Response
{
    public class UpdateProjectResponse
    {
        public UpdateProjectResponseData Response { get; set; } = new UpdateProjectResponseData();
    }

    public class UpdateProjectResponseData : BaseResponse
    {
        public List<Project> data { get; set; } = new List<Project>();
    }
}
