using Serilog;
using Flurl;
using Flurl.Http;
using Tradogram.REST.SDK.DTO.Response;
using Tradogram.REST.SDK.DTO.Request;

namespace Tradogram.REST.SDK.Endpoints
{
    public class GlAccountAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "gl_accounts";

        public async Task<GetGlAccountResponse> GetAllGlAccounts()
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}");

            var response = new GetGlAccountResponse();

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetGlAccountResponse>();

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

        public async Task<GetGlAccountResponse> GetGlAccountByCode(string glAccountCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{glAccountCode}");

            var response = new GetGlAccountResponse();

            if (string.IsNullOrWhiteSpace(glAccountCode))
            {
                Log.Warning("GL account code is null or empty");
                return response; // Return empty response if code is invalid
            }

            if (glAccountCode.Length > 12) // Assuming max length for GL account code is 50 characters
            {
                Log.Warning("GL account code exceeds maximum length of 12 characters");
                return response; // Return empty response if code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(glAccountCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetGlAccountResponse>();

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

        public async Task<CreateGlAccountResponse> CreateGlAccount(CreateGlAccountRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/gl_account/create");
            var response = new CreateGlAccountResponse();

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("gl_account")
                    .AppendPathSegment("create")
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(request)
                    .ReceiveJson<CreateGlAccountResponse>();

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

        public async Task<UpdateGlAccountResponse> UpdateGlAccount(string glAccountCode, UpdateGlAccountRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/gl_account/update/{glAccountCode}");
            var response = new UpdateGlAccountResponse();

            if (string.IsNullOrWhiteSpace(glAccountCode))
            {
                Log.Warning("GL account code is null or empty");
                return response; // Return empty response if code is invalid
            }

            if (glAccountCode.Length > 12) // Assuming max length for GL account code is 50 characters
            {
                Log.Warning("GL account code exceeds maximum length of 12 characters");
                return response; // Return empty response if code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("gl_account")
                    .AppendPathSegment("update")
                    .AppendPathSegment(glAccountCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(request)
                    .ReceiveJson<UpdateGlAccountResponse>();

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
