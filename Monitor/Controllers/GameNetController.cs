using Application.Dto.GameNet.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers;

public class GameNetController(IGameNetApplication service) : ControllerBase
{
  [HttpPost("[action]")]
  public async Task<IActionResult> AddGameNetAsync(
    [FromBody] AddGameNetDto input)
  {
    var result = await service.AddGameNetAsync(input);
    return StatusCode(result.StatusCode, result);
  }
}
