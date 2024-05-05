using Application.Common.Statics;
using Application.Dto;

namespace Application.Interfaces;

public interface IAuthService
{
  Task<ResponseDto?> Register(RegisterDTo input);
}
