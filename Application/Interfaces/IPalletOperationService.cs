using Application.Common.Statics;
using Application.Dto.PalletOperation.Request;

namespace Application.Interfaces;

public interface IPalletOperationService
{
    Task<ResponseDto> GetPalletOperationByInputCountAsync(GetPalletOperationByInputCountRequestDto input);
}