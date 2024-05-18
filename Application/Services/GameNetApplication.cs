using System.Net;
using Application.Common.Responses;
using Application.Common.Statics;
using Application.Dto.GameNet.Request;
using Application.Interfaces;
using FrameWork.ExMethods;
using FrameWork.Services;
using Infra.Data.Repositories.City;
using Infra.Data.Repositories.GameNet;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class GameNetApplication : IGameNetApplication
{
  private readonly IGameNetRepository _repository;
  private readonly ICityRepository _cityepository;
  private readonly IResponse _response;
  private readonly ISerilogger _serilogger;


  public GameNetApplication(IGameNetRepository repository, ICityRepository cityepository, IResponse response,
    ISerilogger serilogger)
  {
    _repository = repository;
    _cityepository = cityepository;
    _response = response;
    _serilogger = serilogger;
  }

  public async Task<ResponseDto> AddGameNetAsync(AddGameNetDto input)
  {
    try
    {
      var checkCity = await _cityepository.GetNoTraking.AnyAsync(a => a.Id == input.CityId.ToGuid());
      if (checkCity is false)
      {
        return _response.GenerateResponse(HttpStatusCode.BadRequest,
          ReturnMessages.FailedAdd("شهر"));
      }

      return default;
    }
    catch (Exception e)
    {
      _serilogger.Error(e);
      return _response.GenerateResponse(HttpStatusCode.InternalServerError,
        ReturnMessages.Faile());
    }
  }
}
