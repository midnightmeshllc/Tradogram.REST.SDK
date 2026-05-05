
using Tradogram.REST.SDK.DTO.Response;
using Flurl;
using Serilog;
using Flurl.Http;
using Tradogram.REST.SDK.DTO.Common;
using Tradogram.REST.SDK.DTO.Request;

namespace Tradogram.REST.SDK.Endpoints
{
    public class ItemAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "items";

        public async Task<GetItemResponse> GetAllItems(PaginateResultsRequest paginateRequest)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}");
            var response = new GetItemResponse();

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
                    .ReceiveJson<GetItemResponse>();

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

        public async Task<GetItemResponse> GetItemByCode(string itemCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{itemCode}");
            var response = new GetItemResponse();

            if (string.IsNullOrEmpty(itemCode))
            {
                Log.Warning("Item code is null or empty");
                return response; // Return empty response if item code is invalid
            }

            if (itemCode.Length > 12)
            {
                Log.Warning("Item code exceeds maximum length of 12 characters");
                return response; // Return empty response if item code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(itemCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetItemResponse>();

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

        public async Task<AttachmentRecord> GetItemImage(string itemCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{itemCode}/images");
            var response = new AttachmentRecord();

            if (string.IsNullOrEmpty(itemCode))
            {
                Log.Warning("Item code is null or empty");
                return response; // Return empty response if item code is invalid
            }
            if (itemCode.Length > 12)
            {
                Log.Warning("Item code exceeds maximum length of 12 characters");
                return response; // Return empty response if item code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(itemCode)
                    .AppendPathSegment("images")
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

        public async Task<AttachmentRecord> GetItemAttachment(string itemCode)
        {
            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{itemCode}/attachments");
            var response = new AttachmentRecord();

            if (string.IsNullOrEmpty(itemCode))
            {
                Log.Warning("Item code is null or empty");
                return response; // Return empty response if item code is invalid
            }
            if (itemCode.Length > 12)
            {
                Log.Warning("Item code exceeds maximum length of 12 characters");
                return response; // Return empty response if item code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(itemCode)
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


        public async Task<CreateItemResponse> CreateItem(CreateItemRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/item");
            var response = new CreateItemResponse();

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("item")
                    .AppendPathSegment("create")
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(request)
                    .ReceiveJson<CreateItemResponse>();

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


        public async Task<UpdateItemResponse> UpdateItem(string itemCode, UpdateItemRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/item/update/{itemCode}");
            var response = new UpdateItemResponse();

            if (string.IsNullOrEmpty(itemCode))
            {
                Log.Warning("Item code is null or empty");
                return response; // Return empty response if item code is invalid
            }

            if (itemCode.Length > 12)
            {
                Log.Warning("Item code exceeds maximum length of 12 characters");
                return response; // Return empty response if item code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("item")
                    .AppendPathSegment("update")
                    .AppendPathSegment(itemCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(request)
                    .ReceiveJson<UpdateItemResponse>();

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


        public async Task<CreateItemImageResponse> CreateItemImage(string itemCode, CreateItemImageRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/item/upload_image/{itemCode}");
            var response = new CreateItemImageResponse();

            if (string.IsNullOrEmpty(itemCode))
            {
                Log.Warning("Item code is null or empty");
                return response; // Return empty response if item code is invalid
            }

            if (itemCode.Length > 12)
            {
                Log.Warning("Item code exceeds maximum length of 12 characters");
                return response; // Return empty response if item code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("item")
                    .AppendPathSegment("upload_image")
                    .AppendPathSegment(itemCode)
                    .WithHeader("x-api-key", xapikey)
                    .PostMultipartAsync(mp => mp.AddFile("file", request.FilePath, "image/png"))
                    .ReceiveJson<CreateItemImageResponse>();

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


        public async Task<CreateItemImageResponse> CreateItemSpec(string itemCode, CreateItemImageRequest request)
        {
            Log.Information($"POST {client.BaseUrl}/item/upload_attachment/{itemCode}");
            var response = new CreateItemImageResponse();

            if (string.IsNullOrEmpty(itemCode))
            {
                Log.Warning("Item code is null or empty");
                return response; // Return empty response if item code is invalid
            }

            if (itemCode.Length > 12)
            {
                Log.Warning("Item code exceeds maximum length of 12 characters");
                return response; // Return empty response if item code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("item")
                    .AppendPathSegment("upload_attachment")
                    .AppendPathSegment(itemCode)
                    .WithHeader("x-api-key", xapikey)
                    .PostMultipartAsync(mp => mp.AddFile("file", request.FilePath))
                    .ReceiveJson<CreateItemImageResponse>();

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
