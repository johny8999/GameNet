using Application.Dto.SubEntity.Request;

namespace Application.Interfaces;

public interface ISubEntityApplication
{
  Task<ResponseDto> AddSubEntityByGameNetAndEntityAsync(AddSubEntityByGameNetAndEntityDto input);
  Task<ResponseDto> AddSubEntityAsync(AddSubEntityDto input);
}
