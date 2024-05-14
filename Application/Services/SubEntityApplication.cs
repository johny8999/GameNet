using System.Net;
using Application.Common.Responses;
using Application.Common.Statics;
using Application.Dto.Entity;
using Application.Interfaces;
using FrameWork.Services;
using Infra.Data.Repositories.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class SubEntityApplication : ISubEntityApplication
{
  private readonly ISubEntityRepository _repository;
  private readonly IResponse _response;
  private readonly ISerilogger _serilogger;

  public SubEntityApplication(ISubEntityRepository repository, IResponse response, ISerilogger serilogger)
  {
    _repository = repository;
    _response = response;
    _serilogger = serilogger;
  }

  public async Task<ResponseDto> AddSubEntityAsync(AddEntityDto input)
  {
    try
    {
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
