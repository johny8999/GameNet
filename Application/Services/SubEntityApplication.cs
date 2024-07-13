using Application.Dto.SubEntity;
using Application.Dto.SubEntity.Request;
using Infra.Data.Repositories.Entity;
using Infra.Data.Repositories.GameNet;
using Infra.Data.Repositories.SubEntity;
using Infra.Data.Repositories.SubEntityGameNet;

namespace Application.Services;

public class SubEntityApplication(
  ISubEntityRepository repository,
  IEntityRepository entityRepository,
  IGameNetRepository gameNetRepository,
  IResponse response,
  ISerilogger serilogger,
  IServiceProvider serviceProvider,
  ISubEntityGameNetRepository subEntityGameNetRepository) : ISubEntityApplication
{
  public async Task<ResponseDto> AddSubEntityByGameNetAndEntityAsync(AddSubEntityByGameNetAndEntityDto input)
  {
    try
    {
      #region Validation

      input.CheckModelState(serviceProvider);

      #endregion

      #region Entity Exist

      List<TblEntity>? entityExist;
      {
        entityExist = await entityRepository.GetNoTraking.Where(a => a.Id == input.EntityId.ToGuid()).ToListAsync();
        if (entityExist.Count <= 0)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.FailedAdd("گروه وجود ندارد"));
        }
      }

      #endregion Entity Exist

      #region ExistGameNet

      List<TblGameNet>? existGameNet;
      {
        existGameNet = await gameNetRepository.GetNoTraking
          .Where(a => a.Id == input.EntityId.ToGuid()).ToListAsync();
        if (existGameNet.Count <= 0)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.FailedAdd("گیم نت وجود ندارد"));
        }
      }

      #endregion ExistGameNet

      #region SubEntity Exist

      var subEntityExist = await repository.GetNoTraking
        .Where(a => entityExist.FirstOrDefault()!.Id == input.EntityId.ToGuid()
                    && a.Name == input.Name
                    && existGameNet.FirstOrDefault()!.Id == input.GameNetId.ToGuid()).AnyAsync();
      if (subEntityExist)
      {
        return response.GenerateResponse(HttpStatusCode.BadRequest,
          ReturnMessages.FailedAdd("این قبلا برای این گیم نت ثبت شده است"));
      }

      #endregion SubEntity Exist

      var result = input.Adapt<TblSubEntity>();

      await repository.AddAsync(result);
      return response.GenerateResponse(HttpStatusCode.OK,
        ReturnMessages.SuccessfulAdd("User"));
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

//Add time for vide games
  public async Task<ResponseDto> AddTimeToEntityAsync(AddTimeToEntityDto input)
  {
    return default;
  }

  public async Task<ResponseDto> AddSubEntityAsync(AddSubEntityDto input)
  {
    try
    {
      #region Validation

      input.CheckModelState(serviceProvider);

      #endregion

      #region Cheking Entity

      {
        var cheking = await entityRepository.GetNoTraking.AnyAsync(a => a.Id == input.EntityId.ToGuid());
        if (cheking is false)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.FailedAdd("موجودیت وجود ندارد"));
        }
      }

      #endregion Cheking Entity

      #region Add Entity

      {
        var result = input.Adapt<TblSubEntity>();
        if (await repository.ReturnAddAsync(result))
        {
          return response.GenerateResponse(HttpStatusCode.OK,
            ReturnMessages.SuccessfulAdd("زیر موجودیتها"));
        }

        return response.GenerateResponse(HttpStatusCode.OK,
          ReturnMessages.FailedAdd("زیر موجودیتها"));
      }

      #endregion Add Entity
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
