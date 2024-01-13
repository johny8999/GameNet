using Application.Common.Statics;
using Application.Dto.Production.Request;

namespace Application.Interfaces;

public interface IProductionService
{
  Task<ResponseDto> GetProductionByDayAsync(GetProductionByDayRequestDto input);
  Task<ResponseDto> GetProductionByHoursAsync(GetProductionByHoursRequestDto input);
}
