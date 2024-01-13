using System.Net;
using Application.Common.Statics;
using Application.Dto.UserOperation.Request;
using Application.Dto.UserOperation.Response;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models.OperationTables;
using FrameWork.Exceptions;
using FrameWork.ExMethods;
using FrameWork.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class UserOperationService : IUserOperationService
{
    private readonly IRepository<User_Operation> _repository;
    private readonly ISerilogger _logger;
    private readonly IServiceProvider _serviceProvider;

    public UserOperationService(IRepository<User_Operation> repository, ISerilogger logger,
        IServiceProvider serviceProvider)
    {
        _repository = repository;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public async Task<ResponseDto> GetUserOperationByInputCountAsync(GetUserOperationByInputRequestDto input)
    {
        try
        {
            #region Validations

            input.CheckModelState(_serviceProvider);

            #endregion Validations

            ResponseDto response;
            var orderOperation = await _repository.GetEntitiesByQuery(true)
                .OrderByDescending(a => a.ID).Skip(0).Take(input.Take)
                .Select(a => new
                {
                    a.ID,
                    a.Availabilit,
                    a.Performance,
                    a.Quality,
                    a.OEE
                })
                .ToListAsync();

            var orderOperationDto = orderOperation.Adapt<List<GetUserOperationByInputResponseDto>>();

            response = StaticData.GenerateResponse(HttpStatusCode.OK, ReturnMessages.SuccessfulGet(),
                orderOperationDto, orderOperation.Count);
            return response;
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
}