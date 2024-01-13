using Application.Dto.UserOperation.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers;

public class UserOperationController : ControllerBase
{
    private readonly IUserOperationService _service;

    public UserOperationController(IUserOperationService service)
    {
        _service = service;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUserOperationByInputCount(
        [FromQuery] GetUserOperationByInputRequestDto inputCountRequest)
    {
        var result = await _service.GetUserOperationByInputCountAsync(inputCountRequest);
        return StatusCode(result.StatusCode, result);
    }
}