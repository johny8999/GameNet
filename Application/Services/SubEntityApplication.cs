using System.Net;
using Application.Common.Responses;
using Application.Common.Statics;
using Application.Dto.Entity;
using Application.Interfaces;
using FrameWork.ExMethods;
using FrameWork.Services;
using Infra.Data.Repositories.Entity;
using Infra.Data.Repositories.GameNet;
using Infra.Data.Repositories.SubEntity;
using Microsoft.AspNetCore.Mvc;
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

  [HttpPost("[action]")]
  public async Task<ResponseDto> AddSubEntityByGameNetAndEntityAsync(AddSubEntityByGameNetAndEntityDto input)
  {
    try
    {
      var EntityExist = await _entityRepository.GetNoTraking.AnyAsync(a => a.Id == input.EntityId.ToGuid());
      if (EntityExist is false)
      {
        return _response.GenerateResponse(HttpStatusCode.BadRequest,
          ReturnMessages.FailedAdd("گروه وجود ندارد"));
      }

      var EntityGameNet = await _gameNetRepository.GetNoTraking
        .AnyAsync(a => a.Id == input.EntityId.ToGuid());
      if (EntityGameNet is false)
      {
        return _response.GenerateResponse(HttpStatusCode.BadRequest,
          ReturnMessages.FailedAdd("گیم نت وجود ندارد"));
      }

      var SubEntityExist = _repository.GetNoTraking
        .Where(a => a.TblEntity.Id == input.EntityId.ToGuid()
                    && a.Name == input.Name
                    && a.TblSubEntityGameNets.Any(a => a.TblGameNet.Id == input.GameNetId.ToGuid()));
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
