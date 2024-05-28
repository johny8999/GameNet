using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Runtime.Caching;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Authentication.JWT.Dto;
using Application.Common.Responses;
using Application.Common.Statics;
using Application.Dto.Role.Request;
using Application.Dto.Users.Response;
using Application.Interfaces;
using FrameWork.Exceptions;
using FrameWork.ExMethods;
using Infra.Data.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using FrameWork.Utility;

namespace Application.Authentication.JWT;

public class JwtBuilder : IJwtBuilder
{
  private readonly ILogger _logger;
  private readonly IUserRepository _userRepository;
  private readonly IResponse _response;
  private readonly IRoleApplication _roleApplication;

  public JwtBuilder(ILogger logger, IUserRepository userRepository, IResponse response,
    IRoleApplication roleApplication)
  {
    _logger = logger;
    _userRepository = userRepository;
    _response = response;
    _roleApplication = roleApplication;
  }

  public async Task<ResponseDto?> CreateTokenAsync(CreateTokenDto input)
  {
    try
    {
      #region Get UserData

      OutGetAllUserDetails userDetails = new();
      {
        var user = await _userRepository.Get.Where(a => a.Email == input.UserEmail && a.PasswordHash == input.Password)
          .SingleOrDefaultAsync();
        if (user is null)
        {
          var result = _response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.GeneralPrint("User name or password is incorrect"));
          return result;
        }

        userDetails.Id = user.Id.ToString();
        userDetails.UserName = user.UserName;
        userDetails.Email = user.Email;
        userDetails.FirstName = user.FirstName;
        userDetails.LastName = user.LastName;
      }

      #endregion

      #region GetRole

      List<string> roles = null;
      {
        roles = await _roleApplication.GetRoleNameByUserIdAsync(new GetRoleNameByUserIdDto()
        {
          UserId = userDetails.Id
        });

        if (roles == null)
          throw new ArgumentInvalidException("UserId is invalid");
      }

      #endregion GetRole

      #region Generate Claim

      List<Claim> lstClaims = null;
      {
        lstClaims = new()
        {
          new Claim("Id", userDetails.Id.ToString()),
          new Claim(ClaimTypes.Name, userDetails.UserName),
          new Claim(ClaimTypes.Email, userDetails.Email ?? ""),
          //new Claim(ClaimTypes.MobilePhone, userDetails.PhoneNumber ?? ""),
          new Claim("FirstName", (userDetails.FirstName ?? "")),
          new Claim("LastName", (userDetails.LastName ?? "")),
          // new Claim("IsActive", userDetails.IsActive.ToString()),
          // new Claim("IsProfileComplete", userDetails.IsProfileComplete.ToString()),
        };

        lstClaims.AddRange(roles.Select(val => new Claim(ClaimTypes.Role, val)));
      }

      #endregion

      #region Token Descriptor

      SecurityTokenDescriptor tokenDescriptor = null;
      {
        var key = Encoding.ASCII.GetBytes(AuthConst.SecretCode);
        tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(lstClaims),
          SigningCredentials =
            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
          Issuer = AuthConst.Issuer,
          Audience = AuthConst.Audience,
          IssuedAt = DateTime.Now,
          Expires = DateTime.Now.AddHours(48)
        };
      }

      #endregion

      #region Generate Token

      string generatedToken = "";
      {
        var securityToken = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
        generatedToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
      }

      #endregion

      #region Encrypt Token

      string encryptedToken = "";
      {
        encryptedToken = generatedToken.AesEncrypt(AuthConst.SecretKey);
      }

      #endregion

      #region SaveToken

      {
        SaveToken(new SaveTokenDto
        {
          UserId = userDetails.Id,
          Token = encryptedToken
        });
      }

      #endregion SaveToken

      var response = _response.GenerateResponse(HttpStatusCode.OK,
        ReturnMessages.SuccessfulGet(),
        new OutCreateTokenAsync
        {
          UserId = userDetails.Id,
          Token = encryptedToken
        }
        , 1);
      return response;
    }
    catch (Exception ex)
    {
      _logger.Error(ex.Message);
      var response = _response.GenerateResponse(HttpStatusCode.OK, ReturnMessages.Faile(),
        ex.Message, 1);
      return response;
    }
  }

  public string GenerateRefreshToken()
  {
    var randomNumber = new byte[32];
    using (var rng = RandomNumberGenerator.Create())
    {
      rng.GetBytes(randomNumber);
      return Convert.ToBase64String(randomNumber).TrimEnd('=').Replace("+", "").Replace("/", "");
      ;
    }
  }

  public ClaimsPrincipal GetPrincipalOfExpirationToken(string token)
  {
    try
    {
      var tokenValidationParameters = new TokenValidationParameters
      {
        ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthConst.SecretCode)),
        ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      SecurityToken securityToken;
      var principal = tokenHandler.ValidateToken(token.AesDecrypt(AuthConst.SecretKey), tokenValidationParameters,
        out securityToken);
      var jwtSecurityToken = securityToken as JwtSecurityToken;
      if (jwtSecurityToken == null)
        throw new SecurityTokenException("Invalid token");
      return principal;
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }

  private async Task SaveToken(SaveTokenDto input)
  {
    try
    {
      ObjectCache memoryCache = MemoryCache.Default;
      memoryCache.Set(input.UserId, input.Token, new CacheItemPolicy
      {
        AbsoluteExpiration = DateTime.Now.AddMinutes(15),
        Priority = CacheItemPriority.Default,
      });
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }
}
