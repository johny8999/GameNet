using Application.Dto.SubEntity.Request;

namespace Template.Controllers;

public class SubEntityController(ISubEntityApplication service) : ControllerBase
{
  [HttpPost("[action]")]
  public async Task<IActionResult> AddSubEntityByGameNetAndEntityAsync(
    [FromBody] AddSubEntityByGameNetAndEntityDto input)
  {
    var result = await service.AddSubEntityByGameNetAndEntityAsync(input);
    return StatusCode(result.StatusCode, result);
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> AddSubEntityAsync([FromBody] AddSubEntityDto input)
  {
    var result = await service.AddSubEntityAsync(input);
    return StatusCode(result.StatusCode, result);
  }
}
