using Application.Common.Statics;
using Application.Dto;
using Application.Dto.Users.Request;

namespace Application.Interfaces;

public interface IUserApplication
{
  Task<ResponseDto> LogIn(LogInDto input);
  Task<ResponseDto> RegisterAsync(RegisterDTo input);
}
