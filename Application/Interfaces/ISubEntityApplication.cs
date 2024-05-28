using Application.Common.Statics;
using Application.Dto.SubEntity;

namespace Application.Interfaces;

public interface ISubEntityApplication
{
  Task<ResponseDto> AddSubEntityByGameNetAndEntityAsync(AddSubEntityByGameNetAndEntityDto input);
}
