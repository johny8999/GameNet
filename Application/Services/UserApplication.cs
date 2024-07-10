using Application.Authentication.JWT;
using Application.Authentication.JWT.Dto;
using Application.Dto;
using Application.Dto.Users.Request;
using Application.Dto.Users.Response;
using Infra.Data.Repositories.UserRole;
using Infra.Data.Repositories.Users;

namespace Application.Services;

public class UserApplication(
  IUserRepository userRepository,
  IResponse response,
  IJwtBuilder builder,
  IUserRoleRepository userRoleRepository,
  ISerilogger serilogger)
  : IUserApplication
{
  public async Task<ResponseDto> LoginByEmailPasswordAsync(LoginByEmailPasswordDto input)
  {
    try
    {
      var jwtBuilder = await builder.CreateTokenAsync(new CreateTokenDto
      {
        UserEmail = input.Email,
        Password = input.Password.ToString()
      });

      if (jwtBuilder != null && jwtBuilder.StatusCode is not 200)
      {
        return jwtBuilder;
      }

      //return jwtBuilder;
      var createTokenResult = jwtBuilder!.Result.Adapt<OutCreateTokenAsync>();
      builder.GetPrincipalOfExpirationToken(createTokenResult.Token);

      return response.GenerateResponse(HttpStatusCode.OK
        , ReturnMessages.GeneralPrint("Login was successful.")
        , new OutLoginByEmail()
        {
          RefreshToken = builder.GenerateRefreshToken(),
          Token = createTokenResult.Token
        });
    }
    catch (Exception e)
    {
      serilogger.Error(e);
      return response.GenerateResponse(HttpStatusCode.InternalServerError,
        ReturnMessages.Faile());
    }
  }

  public async Task<ResponseDto> RegisterAsync(RegisterDTo input)
  {
    try
    {
      #region checkEmail

      {
        var checkEmail = await userRepository.GetNoTraking.AnyAsync(a => a.Email == input.Email);
        if (checkEmail)
        {
          // _logger.Error("Email is Used");
          var response1 = response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.Douplicate("ایمیل"));
          return response1;
        }
      }

      #endregion checkEmail

      #region chek National code

      {
        var checkNationalCode = await userRepository.GetNoTraking.AnyAsync(a => a.NationalCode == input.NationalCode);
        if (checkNationalCode)
        {
          // _logger.Error("Email is Used");
          var response1 = response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.Douplicate("کد ملی"));
          return response1;
        }
      }

      #endregion chek National code

      #region Add User

      TblUsers user = new();
      {
        user.Email = input.Email;
        user.FirstName = input.FirstName;
        user.LastName = input.LastName;
        user.PasswordHash = input.Password;
        user.NormalizedEmail = input.Email;
        user.NationalCode = input.NationalCode;
        user.UserName = input.Email;

        await userRepository.AddAsync(user);
      }

      #endregion Add User

      #region addUserRole

      await userRoleRepository.AddAsync(new TblUserRole
      {
        UserId = user.Id,
        RoleId = "ef23660b-8344-4243-8276-576845a1b264".ToGuid()
      });

      #endregion addUserRole

      var result = response.GenerateResponse(HttpStatusCode.OK,
        ReturnMessages.SuccessfulAdd("User"));
      return result;
    }
    catch (Exception e)
    {
      serilogger.Error(e);
      return response.GenerateResponse(HttpStatusCode.InternalServerError,
        ReturnMessages.Faile());
    }
  }

  public async Task<string> Decript(string encript)
  {
    return "Bearer " + encript.AesDecrypt(AuthConst.SecretKey);
  }
}
