using Application.Dto.SubEntity;

namespace Application.Interfaces;

public interface ISubEntityApplication
{
  Task<ResponseDto> AddSubEntityByGameNetAndEntityAsync(AddSubEntityByGameNetAndEntityDto input);
}
