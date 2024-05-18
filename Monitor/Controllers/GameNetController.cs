using Application.Dto.GameNet.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers;

public class GameNetController : ControllerBase
{
  private readonly IGameNetApplication _service;

  public GameNetController(IGameNetApplication service)
  {
    _service = service;
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> AddGameNetAsync(
    [FromBody] AddGameNetDto input)
  {
    var result = await _service.AddGameNetAsync(input);
    return StatusCode(result.StatusCode, result);
  }
}
