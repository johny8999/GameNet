using System.Net;
using Application.Common.Statics;
using Application.Dto.Production.Request;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using FrameWork.Exceptions;
using FrameWork.ExMethods;
using FrameWork.Services;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class ProductionService : IProductionService
{
  private readonly IRepository<Production> _repository;
  private readonly ISerilogger _logger;
  private readonly IServiceProvider _serviceProvider;

  public ProductionService(IRepository<Production> repository, ISerilogger logger, IServiceProvider serviceProvider)
  {
    _repository = repository;
    _logger = logger;
    _serviceProvider = serviceProvider;
  }

  public async Task<ResponseDto> GetProductionByDayAsync(GetProductionByDayRequestDto input)
  {
    try
    {
      #region Validations

      input.CheckModelState(_serviceProvider);

      #endregion Validations

      #region bussiness paln

      {
        var production = await _repository.GetEntitiesByQuery()
          .Where(a => a.End_Product > DateTime.Now.AddDays(-7) && a.End_Product <= DateTime.Now)
          .GroupBy(a => a.End_Product.Day)
          .Select(a => new
          {
            Quantity = a.Sum(production1 => production1.Quantity),
            QuantityPlan = a.Sum(production1 => production1.QuantityPlan),
            End_Product = a.Select(production1 => production1.End_Product).First().ToString("yy-MM-dd")
          })
          .ToListAsync();

        var response = StaticData.GenerateResponse(HttpStatusCode.OK, ReturnMessages.SuccessfulGet(),
          production, production.Count);
        return response;
      }

      #endregion bussiness paln
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

  public async Task<ResponseDto> GetProductionByHoursAsync(GetProductionByHoursRequestDto input)
  {
    try
    {
      #region Validations

      input.CheckModelState(_serviceProvider);

      #endregion Validations

      #region bussiness paln

      {
        ResponseDto response;


        var production = await _repository.GetEntitiesByQuery()
          .Where(a => a.End_Product.Date >= DateTime.Now.Date.AddDays(-1))
          .Where(a => a.End_Product.Hour > a.End_Product.AddHours(-8).Hour && a.End_Product <= DateTime.Now.AddHours(0))
          .GroupBy(a=>a.End_Product.Hour)
          .Select(a=>new
          {
            Quantity = a.Sum(production1 => production1.Quantity),
            QuantityPlan = a.Sum(production1 => production1.QuantityPlan),
            End_Product = a.Key
          })
          .ToListAsync();

        response = StaticData.GenerateResponse(HttpStatusCode.OK, ReturnMessages.SuccessfulGet(),
          production, production.Count);
        return response;


      }
    }

    #endregion bussiness paln

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
