using Tradogram.REST.SDK.DTO.Response;
using Flurl;
using Flurl.Http;
using Serilog;
using Tradogram.REST.SDK.DTO.Request;
using Tradogram.REST.SDK.DTO.Common;

namespace Tradogram.REST.SDK.Endpoints
{
    public class BranchAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "branches";

        public async Task<GetBranchResponse> GetAllBranches(PaginateResultsRequest paginateRequest, BranchFilter filter)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}");
            Log.Information("Getting all branches");

            var response = new GetBranchResponse();

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

                    if (!string.IsNullOrWhiteSpace(filter.BranchName))
                    {
                        request.AppendQueryParam("branchName", filter.BranchName);
                    }

                    // For date/time or nullable value types, check for HasValue / not null
                    if (filter.CreatedDateStart != null)
                    {
                        request.AppendQueryParam("createdDateStart", filter.CreatedDateStart);
                    }

                    if (filter.CreatedDateEnd != null)
                    {
                        request.AppendQueryParam("createdDateEnd", filter.CreatedDateEnd);
                    }

                    if (filter.ModifiedDateStart != null)
                    {
                        request.AppendQueryParam("modifiedDateStart", filter.ModifiedDateStart);
                    }

                    if (filter.ModifiedDateEnd != null)
                    {
                        request.AppendQueryParam("modifiedDateEnd", filter.ModifiedDateEnd);
                    }
                }


                response = await request
                    .GetAsync()
                    .ReceiveJson<GetBranchResponse>();

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
                return response; // Return empty response on bad request
            }
            catch (FlurlHttpException ex) when (ex.Call.Response != null && ex.Call.Response.StatusCode == 404)
            {
                // Handle 404 Not Found
                Log.Error("Resource not found: {Message}", ex.Message);
                return response; // Return empty response on 404
            }
            catch (FlurlParsingException ex)
            {
                // Handle JSON parsing errors
                Log.Error("Error parsing response: {Message}", ex.Message);
                return response; // Return empty response on parsing error
            }
            catch (FlurlHttpTimeoutException ex)
            {
                // Handle timeout
                Log.Error("Request timed out: {Message}", ex.Message);
                return response; // Return empty response on timeout
            }

            return response;
        }

        public async Task<GetBranchResponse> GetBranchByCode(string branchCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{branchCode}");
            Log.Information("Getting branch by code: {BranchCode}", branchCode);

            var response = new GetBranchResponse();

            if (string.IsNullOrWhiteSpace(branchCode))
            {
                Log.Warning("Branch code is null or empty");
                return response; // Return empty response if branch code is invalid
            }

            if (branchCode.Length > 12)
            {
                Log.Warning("Branch code exceeds maximum length of 12 characters");
                return response; // Return empty response if branch code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment($"{_endpoint}/{branchCode}")
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetBranchResponse>();

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
                return response; // Return empty response on bad request
            }
            catch (FlurlHttpException ex) when (ex.Call.Response != null && ex.Call.Response.StatusCode == 404)
            {
                // Handle 404 Not Found
                Log.Error("Resource not found: {Message}", ex.Message);
                return response; // Return empty response on 404
            }
            catch (FlurlParsingException ex)
            {
                // Handle JSON parsing errors
                Log.Error("Error parsing response: {Message}", ex.Message);
                return response; // Return empty response on parsing error
            }
            catch (FlurlHttpTimeoutException ex)
            {
                // Handle timeout
                Log.Error("Request timed out: {Message}", ex.Message);
                return response; // Return empty response on timeout
            }

            return response;
        }

    }
}
