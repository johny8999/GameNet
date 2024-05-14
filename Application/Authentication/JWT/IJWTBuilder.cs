using System.Security.Claims;
using Application.Authentication.JWT.Dto;
using Application.Common.Statics;

namespace Application.Authentication.JWT;

public interface IJwtBuilder
{
  Task<ResponseDto?> CreateTokenAsync(CreateTokenDto input);
  public string GenerateRefreshToken();
  ClaimsPrincipal GetPrincipalOfExpirationToken(string token);

}
