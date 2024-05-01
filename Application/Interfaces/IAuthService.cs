using Application.Common.Statics;
using Application.Dto;

namespace Application.Interfaces;

public interface IAuthService
{
  Task<ResponseDto?> GetTokensync(GetGetTokensynctRequestDto input);
}
