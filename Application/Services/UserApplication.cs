using System.Net;
using Application.Authentication.JWT;
using Application.Authentication.JWT.Dto;
using Application.Common.Responses;
using Application.Common.Statics;
using Application.Dto;
using Application.Dto.Users.Request;
using Application.Interfaces;
using Domain.Models;
using Infra.Data.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class UserApplication : IUserApplication
{
  private readonly IUserRepository _userRepository;
  private readonly IResponse _response;
  private readonly IJwtBuilder _jwtBuilder;

  public UserApplication(
    IUserRepository userRepository,
    IResponse response, IJwtBuilder jwtBuilder)
  {
    _userRepository = userRepository;

    _response = response;
    _jwtBuilder = jwtBuilder;
  }

  public async Task<ResponseDto> LoginByEmailPasswordAsync(LoginByEmailPasswordDto input)
  {
    try
    {
      var jwtBuilder = await _jwtBuilder.CreateTokenAsync(new CreateTokenDto
      {
        UserEmail = input.Email
      });
      return jwtBuilder;
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }


  public async Task<ResponseDto> RegisterAsync(RegisterDTo input)
  {
    try
    {
      var checkEmail = await _userRepository.GetNoTraking.AnyAsync(a => a.Email == input.Email);
      if (checkEmail)
      {
        // _logger.Error("Email is Used");
        var response = _response.GenerateResponse(HttpStatusCode.BadRequest, ReturnMessages.Douplicate("Email"));
        return response;
      }

      TblUsers user = new()
      {
        Email = input.Email,
        FirstName = input.FirstName,
        LastName = input.LastName,
        Date = DateTime.Now,
        PasswordHash = input.Password,
        UserName = input.Email //.Split('@')[0] + new Random().Next(1000, 9999),
      };
      await _userRepository.AddAsync(user);
      var result = _response.GenerateResponse(HttpStatusCode.OK, ReturnMessages.SuccessfulAdd("User"));
      return result;
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }
}
