using Application.Dto.GameNet.Request;
using Application.Dto.GameNet.Response;
using Infra.Data.Repositories.City;
using Infra.Data.Repositories.GameNet;

namespace Application.Services;

public class GameNetApplication(
  IGameNetRepository repository,
  ICityRepository cityepository,
  IResponse response,
  ISerilogger serilogger,
  IServiceProvider serviceProvider)
  : IGameNetApplication
{
  public async Task<ResponseDto> AddGameNetAsync(AddGameNetDto input)
  {
    try
    {
      #region Validation

      input.CheckModelState(serviceProvider);

      #endregion

      var checkCity = await cityepository.GetNoTraking.AnyAsync(a => a.Id == input.CityId.ToGuid());
      if (checkCity is false)
      {
        return response.GenerateResponse(HttpStatusCode.BadRequest,
          ReturnMessages.NotExist("شهر"));
      }

      var result = input.Adapt<TblGameNet>();
      await repository.AddAsync(result);
      return response.GenerateResponse(HttpStatusCode.OK,
        ReturnMessages.SuccessfulAdd("گیم نت"));
    }
    catch (ArgumentInvalidException ex)
    {
      serilogger.Debug(ex);
      return response.GenerateResponse(HttpStatusCode.BadRequest,
        ReturnMessages.GeneralPrint(ex.Message));
    }
    catch (ArgumentException ex)
    {
      serilogger.Debug(ex.Message);
      return response.GenerateResponse(HttpStatusCode.BadRequest,
        ReturnMessages.GeneralPrint(ex.Message));
    }

    catch (Exception ex)
    {
      serilogger.Error(ex);
      return response.GenerateResponse(HttpStatusCode.InternalServerError,
        ReturnMessages.GeneralPrint("خطایی رخ داد"));
    }
  }

  public async Task<ResponseDto> GetByIdAsync(GetGameNetByIdDto input)
  {
    try
    {
      #region Validation

      input.CheckModelState(serviceProvider);

      #endregion

      #region Get Game Net

      {
        var gameNet = await repository
          .GetNoTraking.SingleOrDefaultAsync(a => a.Id == input.Id.ToGuid());

        if (gameNet is null)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.FailedGet("گیم نت وجود ندارد"));
        }

        var result = new GetGameNetByIdResponseDto
        {
          Id = gameNet.Id.ToString(),
          Name = gameNet.Name
        };

        return response.GenerateResponse(HttpStatusCode.OK,
          ReturnMessages.SuccessfulGet("گیم نت"), result);
      }

      #endregion Get Game Net
    }
    catch (ArgumentException ex)
    {
      serilogger.Debug(ex.Message);
      return response.GenerateResponse(HttpStatusCode.BadRequest,
        ReturnMessages.GeneralPrint(ex.Message));
    }

    catch (Exception ex)
    {
      serilogger.Error(ex);
      return response.GenerateResponse(HttpStatusCode.InternalServerError,
        ReturnMessages.GeneralPrint("خطایی رخ داد"));
    }

  }
}
