using Tradogram.REST.SDK.DTO.Common;
using Tradogram.REST.SDK.DTO.Request;
using Tradogram.REST.SDK.DTO.Response;
using Flurl;
using Flurl.Http;
using Serilog;

namespace Tradogram.REST.SDK.Endpoints
{
    public class SupplierAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "suppliers";


        public async Task<GetSupplierResponse> GetAllSuppliers(PaginateResultsRequest paginateRequest, SupplierFilter filter)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}");

            var response = new GetSupplierResponse();

            try
            {
                var request = $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json");

                // Pagination: add only when requested
                if (paginateRequest != null && paginateRequest.Paginate)
                {
                    request
                        .AppendQueryParam("paginate", paginateRequest.Paginate)
                        .AppendQueryParam("pageSize", paginateRequest.PageSize)
                        .AppendQueryParam("page", paginateRequest.Page);
                }

                // Filters: add only non-null / non-empty values
                if (filter != null && filter.IsEnabled)
                {
                    // Assuming `status` and `branchName` are strings
                    if (!string.IsNullOrWhiteSpace(filter.Status))
                    {
                        request.AppendQueryParam("status", filter.Status);
                    }

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
                    .ReceiveJson<GetSupplierResponse>();

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


        public async Task<GetSupplierResponse> GetSupplierByCode(string supplierCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{supplierCode}");

            var response = new GetSupplierResponse();

            if (string.IsNullOrWhiteSpace(supplierCode))
            {
                Log.Warning("Supplier code is null or empty");
                return response; // Return empty response if supplier code is invalid
            }

            if (supplierCode.Length > 12 || supplierCode.Length < 12)
            {
                Log.Warning("Supplier code must be 12 characters");
                return response; // Return empty response if supplier code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(supplierCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetSupplierResponse>();

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


        public async Task<AttachmentRecord> GetSupplierAttachment(string supplierCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{supplierCode}/attachments");

            var response = new AttachmentRecord();

            if (string.IsNullOrWhiteSpace(supplierCode))
            {
                Log.Warning("Supplier code is null or empty");
                return response; // Return empty response if supplier code is invalid
            }

            if (supplierCode.Length > 12 || supplierCode.Length < 12)
            {
                Log.Warning("Supplier code must be 12 characters");
                return response; // Return empty response if supplier code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(supplierCode)
                    .AppendPathSegment("attachments")
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<AttachmentRecord>();

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
            catch (FlurlHttpException ex)
            {
                // Handle other HTTP exceptions
                Log.Error("Flurl HTTP error: {Message}", ex.Message);
                return response; // Return empty response on other HTTP errors
            }

            return response;
        }


        public async Task<CreateSupplierResponse> CreateSupplier(CreateSupplierRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/supplier/create");
            Log.Information("Creating supplier with company name: {CompanyName}", request.CompanyName);
            var response = new CreateSupplierResponse();

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("supplier")
                    .AppendPathSegment("create")
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(request)
                    .ReceiveJson<CreateSupplierResponse>();

                Log.Debug("Received response: {@Response}", response);

                if (response.Response.Success == true)
                {
                    Log.Information("Supplier created successfully with code: {SupplierCode}", 
                        response.Response.data[0].SupplierCode);
                }

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
            catch (FlurlHttpException ex)
            {
                // Handle other HTTP exceptions
                Log.Error("Flurl HTTP error: {Message}", ex.Message);
                return response; // Return empty response on other HTTP errors
            }

            return response;

        }


        public async Task<UpdateSupplierResponse> UpdateSupplier(string supplierCode, UpdateSupplierRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/supplier/update/{supplierCode}");
            var response = new UpdateSupplierResponse();

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("supplier")
                    .AppendPathSegment("update")
                    .AppendPathSegment(supplierCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(request)
                    .ReceiveJson<UpdateSupplierResponse>();

                Log.Debug("Received response: {@Response}", response);

                if (response.Response.Success == true)
                {
                    Log.Information("Supplier updated successfully with code: {SupplierCode}",
                        response.Response.data[0].SupplierCode);
                }

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
            catch (FlurlHttpException ex)
            {
                // Handle other HTTP exceptions
                Log.Error("Flurl HTTP error: {Message}", ex.Message);
                return response; // Return empty response on other HTTP errors
            }

            return response;

        }

    }
}
