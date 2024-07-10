using Application.Dto.GameNet.Request;
using Application.Dto.GameNet.Response;
using Infra.Data.Repositories.City;
using Infra.Data.Repositories.GameNet;

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

  public async Task<ResponseDto> GetByIdAsync(GetGameNetByIdDto input)
  {
    #region Validation

    input.CheckModelState(_serviceProvider);

    #endregion

    #region Get Game Net

    {
      var gameNet = await _repository
        .GetNoTraking.SingleOrDefaultAsync(a => a.Id == input.Id.ToGuid());

      if (gameNet is null)
      {
        return _response.GenerateResponse(HttpStatusCode.BadRequest,
          ReturnMessages.FailedGet("گیم نت وجود ندارد"));
      }

      var result = new GetGameNetByIdResponseDto
      {
        Id = gameNet.Id.ToString(),
        Name = gameNet.Name
      };

      return _response.GenerateResponse(HttpStatusCode.OK,
        ReturnMessages.SuccessfulGet("گیم نت"), result);
    }

    #endregion Get Game Net
  }
}
