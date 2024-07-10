using Application.Dto.GameNet.Request;

namespace Application.Interfaces;

public interface IGameNetApplication
{
  Task<ResponseDto> AddGameNetAsync(AddGameNetDto input);
  Task<ResponseDto> GetByIdAsync(GetGameNetByIdDto input);
}
