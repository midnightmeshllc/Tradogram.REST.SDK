using Tradogram.REST.SDK.DTO.Common;
using Tradogram.REST.SDK.DTO.Request;
using Tradogram.REST.SDK.DTO.Response;
using Flurl;
using Flurl.Http;
using Serilog;

namespace Tradogram.REST.SDK.Endpoints
{
    public class DeliveryAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "deliveries";

        public async Task<GetDeliveryResponse> GetAllDeliveries(PaginateResultsRequest paginateRequest)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}");
            var response = new GetDeliveryResponse();

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
                    .ReceiveJson<GetDeliveryResponse>();
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

        public async Task<GetDeliveryResponse> GetDeliveryByCode(string deliveryCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{deliveryCode}");
            var response = new GetDeliveryResponse();

            if (string.IsNullOrWhiteSpace(deliveryCode))
            {
                Log.Error("Delivery code cannot be null or empty.");
                return response; // Return empty response if delivery code is invalid
            }

            if (deliveryCode.Length > 12) // Assuming a max length for delivery code
            {
                Log.Error("Delivery code exceeds maximum length of 12 characters.");
                return response; // Return empty response if delivery code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(deliveryCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetDeliveryResponse>();
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

        public async Task<AttachmentRecord> GetDeliveryAttachment(string deliveryCode)
        {

            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{deliveryCode}/attachments");

            var response = new AttachmentRecord();

            if (string.IsNullOrWhiteSpace(deliveryCode))
            {
                Log.Warning("Delivery code is null or empty");
                return response; // Return empty response if invoice code is invalid
            }

            if (deliveryCode.Length > 12)
            {
                Log.Warning("Delivery code exceeds maximum length of 12 characters");
                return response; // Return empty response if invoice code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(deliveryCode)
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

        public async Task<CreateDeliveryResponse> CreateDelivery(CreateDeliveryRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/delivery/create");
            var response = new CreateDeliveryResponse();

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("delivery")
                    .AppendPathSegment("create")
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(request)
                    .ReceiveJson<CreateDeliveryResponse>();

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

        public async Task<UpdateDeliveryResponse> UpdateDelivery(string deliveryCode, UpdateDeliveryRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/delivery/update/{deliveryCode}");
            var response = new UpdateDeliveryResponse();

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("delivery")
                    .AppendPathSegment("update")
                    .AppendPathSegment(deliveryCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(request)
                    .ReceiveJson<UpdateDeliveryResponse>();

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
