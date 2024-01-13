using Application.Dto.Production.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers;

public class ProductionController : ControllerBase
{
  private readonly IProductionService _service;

  public ProductionController(IProductionService service)
  {
    _service = service;
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetProductionByDay(
    [FromQuery] GetProductionByDayRequestDto inputRequestCount)
  {
    var result = await _service.GetProductionByDayAsync(inputRequestCount);
    return StatusCode(result.StatusCode, result);
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetProductionByHours(
    [FromQuery] GetProductionByHoursRequestDto inputRequestCount)
  {
    var result = await _service.GetProductionByHoursAsync(inputRequestCount);
    return StatusCode(result.StatusCode, result);
  }
}
