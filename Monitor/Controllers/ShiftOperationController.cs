using Application.Dto.ShiftOperation.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers;

public class ShiftOperationController : ControllerBase
{
    private readonly IShiftOperationService _service;

    public ShiftOperationController(IShiftOperationService service)
    {
        _service = service;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetShiftOperationByInputCount(
        [FromQuery] GetShiftOperationByInputRequestDto inputRequestCount)
    {
        var result = await _service.GetShiftOperationByInputCountAsync(inputRequestCount);
        return StatusCode(result.StatusCode, result);
    }
}