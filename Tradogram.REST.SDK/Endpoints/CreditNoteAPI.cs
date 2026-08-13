
using Tradogram.REST.SDK.DTO.Response;
using Flurl.Http;
using Serilog;
using Flurl;
using Tradogram.REST.SDK.DTO.Common;
using Tradogram.REST.SDK.DTO.Request;

namespace Tradogram.REST.SDK.Endpoints
{
    public class CreditNoteAPI(FlurlClient client, string xapikey)
    {
        private readonly string _endpoint = "credit_notes";

        public async Task<GetCreditNoteResponse> GetAllCreditNotes(PaginateResultsRequest paginateRequest, CreditNoteFilter filter)
        {
            var response = new GetCreditNoteResponse();

            Log.Information($"GET {client.BaseUrl}/{_endpoint}");

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
                    .ReceiveJson<GetCreditNoteResponse>();

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

        public async Task<GetCreditNoteResponse> GetCreditNoteByCode(string creditNoteCode)
        {
            var response = new GetCreditNoteResponse();

            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{creditNoteCode}");

            if (string.IsNullOrEmpty(creditNoteCode))
            {
                Log.Warning("Credit note code is null or empty");
                return response; // Return empty response if credit note code is invalid
            }

            if (creditNoteCode.Length > 12)
            {
                Log.Warning("Credit note code exceeds maximum length of 12 characters");
                return response; // Return empty response if credit note code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(creditNoteCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<GetCreditNoteResponse>();
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


        public async Task<AttachmentRecord> GetCreditNoteAttachment(string creditNoteCode)
        {
            var response = new AttachmentRecord();

            Log.Information($"GET {client.BaseUrl}/{_endpoint}/{creditNoteCode}/attachments");

            if (string.IsNullOrEmpty(creditNoteCode))
            {
                Log.Warning("Credit note code is null or empty");
                return response; // Return empty response if credit note code is invalid
            }

            if (creditNoteCode.Length > 12)
            {
                Log.Warning("Credit note code exceeds maximum length of 12 characters");
                return response; // Return empty response if credit note code is too long
            }

            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment(_endpoint)
                    .AppendPathSegment(creditNoteCode)
                    .AppendPathSegment("attachments")
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .GetAsync()
                    .ReceiveJson<AttachmentRecord>();
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

        public async Task<UpdateCreditNoteResponse> UpdateCreditNote(string creditNoteCode, UpdateCreditNoteRequest updateRequest)
        {
            var response = new UpdateCreditNoteResponse();
            Log.Information($"PUT {client.BaseUrl}/credit_note/update/{creditNoteCode}");
            if (string.IsNullOrEmpty(creditNoteCode))
            {
                Log.Warning("Credit note code is null or empty");
                return response; // Return empty response if credit note code is invalid
            }
            if (creditNoteCode.Length > 12)
            {
                Log.Warning("Credit note code exceeds maximum length of 12 characters");
                return response; // Return empty response if credit note code is too long
            }
            try
            {
                response = await $"{client.BaseUrl}"
                    .AppendPathSegment("credit_note")
                    .AppendPathSegment("update")
                    .AppendPathSegment(creditNoteCode)
                    .WithHeader("x-api-key", xapikey)
                    .WithHeader("Content-Type", "application/json")
                    .PutJsonAsync(updateRequest)
                    .ReceiveJson<UpdateCreditNoteResponse>();

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
