using System.Net;
using Application.Common.Responses;
using Application.Common.Statics;
using Application.Dto.SubEntity;
using Application.Interfaces;
using Domain.Models;
using FrameWork.ExMethods;
using FrameWork.Services;
using Infra.Data.Repositories.Entity;
using Infra.Data.Repositories.GameNet;
using Infra.Data.Repositories.SubEntity;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class SubEntityApplication : ISubEntityApplication
{
  private readonly ISubEntityRepository _repository;
  private readonly IEntityRepository _entityRepository;
  private readonly IGameNetRepository _gameNetRepository;
  private readonly IResponse _response;
  private readonly ISerilogger _serilogger;


  public SubEntityApplication(ISubEntityRepository repository, IEntityRepository entityRepository,
    IGameNetRepository gameNetRepository, IResponse response, ISerilogger serilogger)
  {
    _repository = repository;
    _entityRepository = entityRepository;
    _gameNetRepository = gameNetRepository;
    _response = response;
    _serilogger = serilogger;
  }

  public async Task<ResponseDto> AddSubEntityByGameNetAndEntityAsync(AddSubEntityByGameNetAndEntityDto input)
  {
    try
    {
      #region Entity Exist

      List<TblEntity>? entityExist;
      {
        entityExist =
          await _entityRepository.GetNoTraking.Where(a => a.Id == input.EntityId.ToGuid()).ToListAsync();
        if (entityExist.Count <= 0)
        {
          return _response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.FailedAdd("گروه وجود ندارد"));
        }
      }

      #endregion Entity Exist

      #region ExistGameNet

      List<TblGameNet>? existGameNet;
      {
        existGameNet = await _gameNetRepository.GetNoTraking
          .Where(a => a.Id == input.EntityId.ToGuid()).ToListAsync();
        if (existGameNet.Count <= 0)
        {
          return _response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.FailedAdd("گیم نت وجود ندارد"));
        }
      }

      #endregion ExistGameNet

      #region SubEntity Exist

      var subEntityExist = await _repository.GetNoTraking
        .Where(a => entityExist.FirstOrDefault()!.Id == input.EntityId.ToGuid()
                    && a.Name == input.Name
                    && existGameNet.FirstOrDefault()!.Id == input.GameNetId.ToGuid()).AnyAsync();
      if (subEntityExist)
      {
        return _response.GenerateResponse(HttpStatusCode.BadRequest,
          ReturnMessages.FailedAdd("این قبلا برای این گیم نت ثبت شده است"));
      }

      #endregion SubEntity Exist

      var result = input.Adapt<TblSubEntity>();

      await _repository.AddAsync(result);
      return _response.GenerateResponse(HttpStatusCode.OK,
        ReturnMessages.SuccessfulAdd("User"));
    }
    catch (Exception e)
    {
      _serilogger.Error(e);
      return _response.GenerateResponse(HttpStatusCode.InternalServerError,
        ReturnMessages.Faile());
    }
  }

//Add time for vide games
  public async Task<ResponseDto> AddTimeToEntityAsync(AddTimeToEntityDto input)
  {
    return default;
  }
}
