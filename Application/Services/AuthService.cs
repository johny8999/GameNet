using System.Net;
using Application.Common.Statics;
using Application.Dto;
using Application.Interfaces;
using FrameWork.Exceptions;
using FrameWork.ExMethods;
using FrameWork.Services;
using Infra.Data.Repositories.Users;
using Microsoft.AspNetCore.Authentication;

namespace Application.Services;

public class AuthService : IAuthService
{
  private readonly IServiceProvider _serviceProvider;
  private readonly ISerilogger _logger;
  private readonly IUserRepository _userRepository;

  public AuthService(IServiceProvider serviceProvider, ISerilogger logger)
  {
    _serviceProvider = serviceProvider;
    _logger = logger;
  }

  public async Task<ResponseDto?> GetTokensync(GetGetTokensynctRequestDto input)
  {
    try
    {
      #region Validations

      input.CheckModelState(_serviceProvider);

      #endregion Validations

      return null;
    }
    catch (ArgumentInvalidException ex)
    {
      _logger.Debug(ex);
      return StaticData.GenerateResponse(HttpStatusCode.BadRequest, ex.Message);
    }
    catch (Exception e)
    {
      _logger.Error(e);
      return StaticData.GenerateResponse(HttpStatusCode.InternalServerError, ReturnMessages.Exception);
    }
  }
}
