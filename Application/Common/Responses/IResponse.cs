using System.Net;
using Application.Common.Statics;

namespace Application.Common.Responses;

public interface IResponse
{
    ResponseDto GenerateResponse(HttpStatusCode statusCode, string message, object? result = null,
        int total = 0, int page = 1, int perPage = 10);
}
