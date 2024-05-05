using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
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
        var user = await _userRepository.Get.Where(a => a.Email == input.UserEmail).SingleOrDefaultAsync();
        if (user is null)
        {
          var result = _response.GenerateResponse(HttpStatusCode.OK, ReturnMessages.SuccessfulAdd("User"));
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

      List<string> _Roles = null;
      {
        _Roles = await _roleApplication.GetRoleNameByUserIdAsync(new GetRoleNameByUserIdDto()
        {
          UserId = userDetails.Id
        });

        if (_Roles == null)
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

        lstClaims.AddRange(_Roles.Select(val => new Claim(ClaimTypes.Role, val)));
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
