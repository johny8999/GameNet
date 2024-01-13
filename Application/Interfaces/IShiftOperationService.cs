using Application.Common.Statics;
using Application.Dto.ShiftOperation.Request;

namespace Application.Interfaces;

public interface IShiftOperationService
{
    Task<ResponseDto> GetShiftOperationByInputCountAsync(GetShiftOperationByInputRequestDto inputRequest);
}