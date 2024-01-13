using Application.Dto.OrderOperation.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers;

public class OrderOperationController : ControllerBase
{
    private readonly IOrderOperationService _service;

    public OrderOperationController(IOrderOperationService service)
    {
        _service = service;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetOrderOperationByInputCount([FromQuery] GetOrderOperationByInputCountRequestDto inputCountRequest)
    {
        var result = await _service.GetOrderOperationByInputCountAsync(inputCountRequest);
        return StatusCode(result.StatusCode, result);
    }
}