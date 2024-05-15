using Application.Dto.Entity;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers;

public class SubEntityController : ControllerBase
{
  private readonly ISubEntityApplication _service;

  public SubEntityController(ISubEntityApplication service)
  {
    _service = service;
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> AddSubEntityByGameNetAndEntityAsync(
    [FromBody] AddSubEntityByGameNetAndEntityDto input)
  {
    var result = await _service.AddSubEntityByGameNetAndEntityAsync(input);
    return StatusCode(result.StatusCode, result);
  }
}
