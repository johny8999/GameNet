using System.Net;
using Application.Common.Responses;
using Application.Common.Statics;
using Application.Dto.GameNet.Request;
using Application.Interfaces;
using Domain.Models;
using FrameWork.Exceptions;
using FrameWork.ExMethods;
using FrameWork.Services;
using Infra.Data.Repositories.City;
using Infra.Data.Repositories.GameNet;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class GameNetApplication : IGameNetApplication
{
  private readonly IGameNetRepository _repository;
  private readonly ICityRepository _cityepository;
  private readonly IResponse _response;
  private readonly ISerilogger _serilogger;
  private readonly IServiceProvider _serviceProvider;


  public GameNetApplication(IGameNetRepository repository, ICityRepository cityepository, IResponse response,
    ISerilogger serilogger, IServiceProvider serviceProvider)
  {
    _repository = repository;
    _cityepository = cityepository;
    _response = response;
    _serilogger = serilogger;
    _serviceProvider = serviceProvider;
  }

  public async Task<ResponseDto> AddGameNetAsync(AddGameNetDto input)
  {
    try
    {
      #region Validation

      input.CheckModelState(_serviceProvider);

      #endregion

      var checkCity = await _cityepository.GetNoTraking.AnyAsync(a => a.Id == input.CityId.ToGuid());
      if (checkCity is false)
      {
        return _response.GenerateResponse(HttpStatusCode.BadRequest,
          ReturnMessages.NotExist("شهر"));
      }

      var result = input.Adapt<TblGameNet>();
      await _repository.AddAsync(result);
      return _response.GenerateResponse(HttpStatusCode.OK,
        ReturnMessages.SuccessfulAdd("گیم نت"));
    }
    catch (ArgumentInvalidException ex)
    {
      _serilogger.Debug(ex);
      return _response.GenerateResponse(HttpStatusCode.BadRequest,
        ReturnMessages.GeneralPrint(ex.Message));
    }
    catch (Exception e)
    {
      _serilogger.Error(e);
      return _response.GenerateResponse(HttpStatusCode.InternalServerError,
        ReturnMessages.Faile());
    }
  }
}
