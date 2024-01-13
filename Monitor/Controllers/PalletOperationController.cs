using Application.Dto.PalletOperation.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers;

public class PalletOperationController : ControllerBase
{
    private readonly IPalletOperationService _service;

    public PalletOperationController(IPalletOperationService service)
    {
        _service = service;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetPalletOperationByInputCount(
        [FromQuery] GetPalletOperationByInputCountRequestDto inputCountRequest)
    {
        var result = await _service.GetPalletOperationByInputCountAsync(inputCountRequest);
        return StatusCode(result.StatusCode, result);
    }
}