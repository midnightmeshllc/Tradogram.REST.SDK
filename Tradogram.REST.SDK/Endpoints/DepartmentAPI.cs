using Serilog;
using Flurl;
using Flurl.Http;
using Tradogram.REST.SDK.DTO.Response;
using Tradogram.REST.SDK.DTO.Request;

namespace Tradogram.REST.SDK.Endpoints
{
    public class DepartmentAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "departments";

        public async Task<GetDepartmentResponse> GetAllDepartments()
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}");

            var response = new GetDepartmentResponse();

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetDepartmentResponse>();

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

        public async Task<GetDepartmentResponse> GetDepartmentByCode(string departmentCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{departmentCode}");
            var response = new GetDepartmentResponse();

            if (string.IsNullOrWhiteSpace(departmentCode))
            {
                Log.Warning("Department code is null or empty");
                return response; // Return empty response if department code is invalid
            }

            if (departmentCode.Length > 12)
            {
                Log.Warning("Department code exceeds maximum length of 12 characters");
                return response; // Return empty response if department code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(departmentCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetDepartmentResponse>();

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

        public async Task<CreateDepartmentResponse> CreateDepartment(CreateDepartmentRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/department/create");
            var response = new CreateDepartmentResponse();

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("department")
                    .AppendPathSegment("create")
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(request)
                    .ReceiveJson<CreateDepartmentResponse>();

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


        public async Task<UpdateDepartmentResponse> UpdateDepartment(string departmentCode, UpdateDepartmentRequest request)
        {
            Log.Information($"PUT {client.BaseUrl}/department/update/{departmentCode}");
            var response = new UpdateDepartmentResponse();

            if (string.IsNullOrWhiteSpace(departmentCode))
            {
                Log.Warning("Department code is null or empty");
                return response; // Return empty response if department code is invalid
            }

            if (departmentCode.Length > 12)
            {
                Log.Warning("Department code exceeds maximum length of 12 characters");
                return response; // Return empty response if department code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("department")
                    .AppendPathSegment("update")
                    .AppendPathSegment(departmentCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(request)
                    .ReceiveJson<UpdateDepartmentResponse>();

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
