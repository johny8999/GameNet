using Application.Common.Statics;
using Application.Dto.Entity;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Interfaces;

public interface ISubEntityApplication
{
  Task<ResponseDto> AddSubEntityByGameNetAndEntityAsync(AddSubEntityByGameNetAndEntityDto input);
}
