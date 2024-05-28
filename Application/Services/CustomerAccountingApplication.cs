using System.Net;
using Application.Common.Responses;
using Application.Common.Statics;
using Application.Dto.CustomerAccounting.Request;
using Application.Interfaces;
using Domain.Models;
using FrameWork.Exceptions;
using FrameWork.ExMethods;
using FrameWork.Services;
using Infra.Data.Repositories.CustomerAccounting;
using Infra.Data.Repositories.GameNet;
using Infra.Data.Repositories.SubEntity;
using Infra.Data.Repositories.SubEntityGameNet;
using Infra.Data.Repositories.Users;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class CustomerAccountingApplication(
  ICustomerAccountingRepository repository,
  IUserRepository userRepository,
  IResponse response,
  ISerilogger serilogger,
  IServiceProvider serviceProvider,
  ISubEntityGameNetRepository subEntityGameNetRepository
)
  : ICustomerAccountingApplication
{
  public async Task<ResponseDto> AddCustomerAccountingAsync(AddCustomerAccountingDto input)
  {
    try
    {
      #region Validation

      input.CheckModelState(serviceProvider);

      #endregion

      #region Cheking

      {
        var checkSubEntityGameNet =
          await subEntityGameNetRepository.GetNoTraking
            .AnyAsync(a => a.Id == input.SubEntityGameNetId.ToGuid());

        if (checkSubEntityGameNet is false)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.NotExist("محصول"));
        }

        var checkUser = await userRepository.GetNoTraking.AnyAsync(a => a.Id == input.UserId.ToGuid());
        if (checkUser is false)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.NotExist("کاربر"));
        }
      }

      #endregion Cheking

      #region Add

      {
        var customerAccount = input.Adapt<TblCustomerAccounting>();
        await repository.AddAsync(customerAccount);
      }

      #endregion Add

      return response.GenerateResponse(HttpStatusCode.OK,
        ReturnMessages.SuccessfulAdd("مبلغ"));
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

  public async Task<ResponseDto> AddCustomerAccountByTimeAsync(AddCustomerAccountByTimeDto input)
  {
    try
    {
      #region Validation

      input.CheckModelState(serviceProvider);

      #endregion

      #region Cheking

      TblSubEntityGameNet? subEntityGameNet = new();
      {
        subEntityGameNet =
          await subEntityGameNetRepository.GetNoTraking
            .SingleOrDefaultAsync(a => a.Id == input.SubEntityGameNetId.ToGuid());

        if (subEntityGameNet is null)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.NotExist("محصول"));
        }

        var checkUser = await userRepository.GetNoTraking.AnyAsync(a => a.Id == input.UserId.ToGuid());
        if (checkUser is false)
        {
          return response.GenerateResponse(HttpStatusCode.BadRequest,
            ReturnMessages.NotExist("کاربر"));
        }
      }

      #endregion Cheking

      #region Add

      {
        //var q = subEntityGameNet.Price / input.PurchaseTime;
        return default;
      }

      #endregion Add
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
