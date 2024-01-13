using Application.Common.Statics;
using Application.Dto.OrderOperation.Request;

namespace Application.Interfaces
{

    public interface IOrderOperationService
    {
        Task<ResponseDto> GetOrderOperationByInputCountAsync(GetOrderOperationByInputCountRequestDto input);
    }
}