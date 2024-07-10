using System.Security.Claims;
using Application.Authentication.JWT.Dto;

namespace Application.Authentication.JWT;

public interface IJwtBuilder
{
  Task<ResponseDto?> CreateTokenAsync(CreateTokenDto input);
  public string GenerateRefreshToken();
  ClaimsPrincipal GetPrincipalOfExpirationToken(string token);

}
