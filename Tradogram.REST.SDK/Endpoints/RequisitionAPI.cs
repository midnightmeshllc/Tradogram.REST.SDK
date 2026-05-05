using Tradogram.REST.SDK.DTO.Common;
using Tradogram.REST.SDK.DTO.Request;
using Tradogram.REST.SDK.DTO.Response;
using Flurl;
using Flurl.Http;
using Serilog;

namespace Tradogram.REST.SDK.Endpoints
{
    public class RequisitionAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "requisitions";

        public async Task<GetRequisitionResponse> GetAllRequisitions(PaginateResultsRequest paginateRequest)
        {

            Log.Information($"GET {client.BaseUrl}/{_endpoint}");

            var response = new GetRequisitionResponse();

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
                    .ReceiveJson<GetRequisitionResponse>();

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


        public async Task<GetRequisitionResponse> GetRequisitionByCode(string requisitionCode)
        {

            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{requisitionCode}");

            var response = new GetRequisitionResponse();

            if (string.IsNullOrWhiteSpace(requisitionCode))
            {
                Log.Warning("Requisition code is null or empty");
                return response; // Return empty response if requisition code is invalid
            }

            if (requisitionCode.Length > 50)
            {
                Log.Warning("Requisition code is exceeds maximum length of 12 characters");
                return response; // Return empty response if requisition code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(requisitionCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetRequisitionResponse>();
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

        public async Task<AttachmentRecord> GetRequisitionAttachment(string requisitionCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{requisitionCode}/attachments");

            var response = new AttachmentRecord();

            if (string.IsNullOrWhiteSpace(requisitionCode))
            {
                Log.Warning("Requisition code is null or empty");
                return response; // Return empty response if requisition code is invalid
            }

            if (requisitionCode.Length > 50)
            {
                Log.Warning("Requisition code is exceeds maximum length of 12 characters");
                return response; // Return empty response if requisition code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(requisitionCode)
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

        public async Task<UpdateRequisitionResponse> UpdateRequisition(string requisitionCode, UpdateRequisitionRequest updateRequest)
        {
            Log.Information($"POST {client.BaseUrl}/requisition/update/{requisitionCode}");
            var response = new UpdateRequisitionResponse();

            if (string.IsNullOrWhiteSpace(requisitionCode))
            {
                Log.Warning("Requisition code is null or empty");
                return response; // Return empty response if requisition code is invalid
            }

            if (requisitionCode.Length > 12)
            {
                Log.Warning("Requisition code is exceeds maximum length of 12 characters");
                return response; // Return empty response if requisition code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("requisition")
                    .AppendPathSegment("update")
                    .AppendPathSegment(requisitionCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PutJsonAsync(updateRequest)
                    .ReceiveJson<UpdateRequisitionResponse>();

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

    }
}
