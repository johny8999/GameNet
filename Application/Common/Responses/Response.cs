using System.Net;
using Application.Common.Statics;

namespace Application.Common.Responses;

public class Response : IResponse
{
    public ResponseDto GenerateResponse(HttpStatusCode statusCode, string message, object? result = null,
        int total = 0, int page = 1, int perPage = 10)
        => new()
        {
            StatusCode = (int)statusCode, Message = new List<string>() { message }, Result = result, Total = total,
            Page = page, PerPage = perPage
        };
}
