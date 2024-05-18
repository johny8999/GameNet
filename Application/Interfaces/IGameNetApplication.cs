using Application.Common.Statics;
using Application.Dto.GameNet.Request;

namespace Application.Interfaces;

public interface IGameNetApplication
{
  Task<ResponseDto> AddGameNetAsync(AddGameNetDto input);
}
