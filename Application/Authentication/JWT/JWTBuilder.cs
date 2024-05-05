using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Application.Common.Statics;
using Application.Dto.Users.Response;
using Application.Interfaces;
using FrameWork.ExMethods;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Application.Authentication.JWT;

public class JwtBuilder : IJwtBuilder
{
  private readonly ILogger _logger;
  private readonly IUserApplication _userApplication;

  public JwtBuilder(IUserApplication userApplication, ILogger logger)
  {
    _userApplication = userApplication;
    _logger = logger;
  }

  public async Task<ResponseDto?> CreateTokenAsync(long UserId)
  {
    try
    {
      #region Get UserData

      OutGetAllUserDetails userDetails = null;
      {
        var result = await _userApplication.LogIn(new()
        {
          UserId = UserId
        });
        if (result.StatusCode != 200)
          return default;

        //TODO:back to correct code
        userDetails = default;
      }

      #endregion

      #region Generate Claim

      List<Claim> lstClaims = null;
      {
        lstClaims = new()
        {
          new Claim("Id", userDetails.Id.ToString()),
          new Claim("SellerId", userDetails.SellerId.ToString()),
          new Claim(ClaimTypes.Name, userDetails.UserName),
          new Claim(ClaimTypes.Email, userDetails.Email ?? ""),
          new Claim(ClaimTypes.MobilePhone, userDetails.PhoneNumber ?? ""),
          new Claim("FullName", (userDetails.FirstName ?? "") + " " + (userDetails.LastName ?? "")),
          new Claim("IsActive", userDetails.IsActive.ToString()),
          new Claim("IsProfileComplete", userDetails.IsProfileComplete.ToString()),
        };

        lstClaims.AddRange(userDetails.Roles.Select(val => new Claim(ClaimTypes.Role, val)));
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
        generatedToken = "Bearer " + new JwtSecurityTokenHandler().WriteToken(securityToken);
      }

      #endregion

      #region Encrypt Token

      string encryptedToken = "";
      {
        encryptedToken = generatedToken.AesEncrypt(AuthConst.SecretKey);
      }

      #endregion

      var response = StaticData.GenerateResponse(HttpStatusCode.OK, ReturnMessages.SuccessfulGet(),
        encryptedToken, 1);
      return response;
    }
    catch (Exception ex)
    {
      _logger.Error(ex.Message);
      var response = StaticData.GenerateResponse(HttpStatusCode.OK, ReturnMessages.Faile(),
        ex.Message, 1);
      return response;
    }
  }
}
