using Serilog;
using Flurl;
using Flurl.Http;
using Tradogram.REST.SDK.DTO.Response;
using Tradogram.REST.SDK.DTO.Request;

namespace Tradogram.REST.SDK.Endpoints
{
    public class CategoryAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "categories";

        public async Task<GetCategoryResponse> GetAllCategories(PaginateResultsRequest? paginateRequest)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}");
            Log.Information("Getting all categories");
            var response = new GetCategoryResponse();

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendQueryParam("paginate", paginateRequest?.Paginate ?? false)
                    .AppendQueryParam("pageSize", paginateRequest?.PageSize ?? 100)
                    .AppendQueryParam("page", paginateRequest?.Page ?? 1)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetCategoryResponse>();

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

        public async Task<GetCategoryResponse> GetCategoryByCode(string categoryCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{categoryCode}");
            Log.Information("Getting category by code: {Code}", categoryCode);
            var response = new GetCategoryResponse();

            if (string.IsNullOrWhiteSpace(categoryCode))
            {
                Log.Warning("Category code is null or empty");
                return response; // Return empty response if code is invalid
            }

            if (categoryCode.Length > 12)
            {
                Log.Warning("Category code exceeds maximum length of 12 characters");
                return response; // Return empty response if code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(categoryCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetCategoryResponse>();

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
