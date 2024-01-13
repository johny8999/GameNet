using Application.Common.Statics;
using Application.Dto.UserOperation.Request;

namespace Application.Interfaces;

public interface IUserOperationService
{
    Task<ResponseDto> GetUserOperationByInputCountAsync(GetUserOperationByInputRequestDto input);
}