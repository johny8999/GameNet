using Application.Dto.GameNet.Request;

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

  [HttpGet("[action]")]
  public async Task<IActionResult> GetByIdAsync([FromQuery] GetGameNetByIdDto input)
  {
    var result = await service.GetByIdAsync(input);
    return StatusCode(result.StatusCode, result);
  }
}
