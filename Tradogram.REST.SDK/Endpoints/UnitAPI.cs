using Serilog;
using Flurl;
using Flurl.Http;
using Tradogram.REST.SDK.DTO.Response;
using Tradogram.REST.SDK.DTO.Request;
using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.Endpoints
{
    public class UnitAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "units";

        public async Task<GetUomResponse> GetAllUOMs(PaginateResultsRequest paginateRequest, UnitFilter filter)
        {
            Log.Information("Getting all units of measurement");

            var response = new GetUomResponse();

            try
            {

                var request = $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json");


                if (paginateRequest.Paginate)
                {
                    request
                        .AppendQueryParam("paginate", paginateRequest?.Paginate ?? false)
                        .AppendQueryParam("pageSize", paginateRequest?.PageSize ?? 100)
                        .AppendQueryParam("page", paginateRequest?.Page ?? 1);
                }


                if (filter != null && filter.IsEnabled)
                {
                    if (!string.IsNullOrEmpty(filter?.UnitGroupName))
                    {
                        request.AppendQueryParam("unitGroupName", filter.UnitGroupName);
                    }
                }

                response = await request
                    .GetAsync()
                    .ReceiveJson<GetUomResponse>();

                Log.Debug("Received response: {@Response}", response);

            }
            catch (FlurlHttpException ex) when (ex.Call.Response != null && ex.Call.Response.StatusCode == 401)
            {
                // Handle 401 Unauthorized
                Log.Error("Unauthorized access: {Message}", ex.Message);
                return response; // Return empty response on unauthorized access
            }
            catch (FlurlHttpException ex) when (ex.Call.Response != null && ex.Call.Response.StatusCode == 400)
            {
                // Handle 400 Bad Request
                Log.Error("Bad request: {Message}", ex.Message);
                return response;
            }
            catch (FlurlHttpException ex) when (ex.Call.Response != null && ex.Call.Response.StatusCode == 404)
            {
                // Handle 404 Not Found
                Log.Error("Resource not found: {Message}", ex.Message);
                return response;
            }
            catch (FlurlParsingException ex)
            {
                // Handle JSON parsing errors
                Log.Error("Error parsing response: {Message}", ex.Message);
                return response;
            }
            catch (FlurlHttpTimeoutException ex)
            {
                // Handle timeout
                Log.Error("Request timed out: {Message}", ex.Message);
                return response;
            }

            return response;
        }
    }
}
