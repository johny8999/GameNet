using Domain.Models;
using FrameWork.Exceptions;
using FrameWork.ExMethods;
using FrameWork.Services;
using Infra.Data.Repositories.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Seed.Entity;

public class SeedEntity:ISeedEntity
{
  private readonly IEntityRepository _repository;
  private readonly ISerilogger _serilogger;

  public SeedEntity(IEntityRepository repository, ISerilogger serilogger)
  {
    _repository = repository;
    _serilogger = serilogger;
  }

  public async Task<bool> RunAsync()
  {
    try
    {
      #region Ball Games

      {
        if (!await _repository.GetNoTraking.AnyAsync(a => a.Id == "dce874d8-8be5-46bf-a4da-3edfc630159c".ToGuid()))
          await _repository.AddAsync(new TblEntity()
          {
            Id = "dce874d8-8be5-46bf-a4da-3edfc630159c".ToGuid(),
            Name = "بازیهای توپی",
          });
      }

      #endregion Ball Games

      #region Buffe

      {
        if (!await _repository.GetNoTraking.AnyAsync(a => a.Id == "c37fab43-3634-4f18-86c3-14cda24c2bf5".ToGuid()))
          await _repository.AddAsync(new TblEntity()
          {
            Id = "c37fab43-3634-4f18-86c3-14cda24c2bf5".ToGuid(),
            Name = "بوفه",
          });
      }

      #endregion Buffe

      #region Video Games

      {
        if (!await _repository.GetNoTraking.AnyAsync(a => a.Id == "ed92cdcc-5e94-4251-abd7-e1a607ad3d30".ToGuid()))
          await _repository.AddAsync(new TblEntity()
          {
            Id = "ed92cdcc-5e94-4251-abd7-e1a607ad3d30".ToGuid(),
            Name = "بازیهای ویدیویی",
          });
      }

      #endregion Video Games

      #region coffe

      {
        if (!await _repository.GetNoTraking.AnyAsync(a => a.Id == "d009c744-5c13-4aa4-bce1-b525ce609f00".ToGuid()))
          await _repository.AddAsync(new TblEntity()
          {
            Id = "d009c744-5c13-4aa4-bce1-b525ce609f00".ToGuid(),
            Name = "کافی شاپ",
          });
      }

      #endregion Coffe

      return true;
    }
    catch (ArgumentInvalidException ex)
    {
      _serilogger.Debug(ex);
      return false;
    }
    catch (Exception ex)
    {
      _serilogger.Error(ex);
      return false;
    }
  }

}
