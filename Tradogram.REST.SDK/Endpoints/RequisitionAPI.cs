using Flurl;
using Flurl.Http;
using Serilog;
using Tradogram.REST.SDK.DTO.Common;
using Tradogram.REST.SDK.DTO.Request;
using Tradogram.REST.SDK.DTO.Response;

namespace Tradogram.REST.SDK.Endpoints
{
    public class RequisitionAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "requisitions";

        public async Task<GetRequisitionResponse> GetAllRequisitions(PaginateResultsRequest paginateRequest, RequisitionFilter? filter)
        {

            Log.Information($"GET {client.BaseUrl}/{_endpoint}");

            var response = new GetRequisitionResponse();

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

                if (filter != null && filter.IsEnabled)
                {
                    if (!string.IsNullOrWhiteSpace(filter.Status))
                    {
                        request.AppendQueryParam("status", filter.Status);
                    }

                    if (!string.IsNullOrWhiteSpace(filter.FetchType.ToString()))
                    {
                        request.AppendQueryParam("fetchType", filter.FetchType);
                    }

                    if (filter.UpdateFetchFlag)
                    {
                        request.AppendQueryParam("updateFetchFlag", filter.UpdateFetchFlag);
                    }

                    if (!string.IsNullOrWhiteSpace(filter.BuyerBranchName))
                    {
                        request.AppendQueryParam("buyerBranchName", filter.BuyerBranchName);
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

            if (requisitionCode.Length > 12 || requisitionCode.Length < 12)
            {
                Log.Warning("Requisition code must be 12 characters");
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

            if (requisitionCode.Length > 12 || requisitionCode.Length < 12)
            {
                Log.Warning("Requisition code must be 12 characters");
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

            if (requisitionCode.Length > 12 || requisitionCode.Length < 12)
            {
                Log.Warning("Requisition code must be 12 characters");
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
