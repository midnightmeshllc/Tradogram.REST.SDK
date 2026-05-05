using Tradogram.REST.SDK.DTO.Request;
using Tradogram.REST.SDK.DTO.Response;
using Flurl;
using Flurl.Http;
using Serilog;

namespace Tradogram.REST.SDK.Endpoints
{
    public class ApprovalAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "approvals";


        /// <summary>
        /// Retrieves the approval matrix configuration for a specified transaction type.
        /// </summary>
        /// <param name="request">The request containing details about the transaction type.</param>
        /// <returns>A task that represents the asynchronous operation, containing the approval matrix response.</returns>
        public async Task<GetApprovalMatrixResponse> GetApprovalMatrixByTransactionType(ApprovalMatrixRequest request)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{request.TransactionType}/{request.TransactionCode}");
            var response = new GetApprovalMatrixResponse();

            if (request.TransactionCode.Length > 12)
            {
                Log.Warning("Transaction code exceeds maximum length of 12 characters");
                return response; // Return empty response if code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(request.TransactionType)
                    .AppendPathSegment(request.TransactionCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetApprovalMatrixResponse>();

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
