using Application.Dto;
using Application.Dto.Users.Request;

namespace Template.Controllers;

public class UserController(IUserApplication service) : ControllerBase
{
  [HttpPost("[action]")]
  public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTo input)
  {
    var result = await service.RegisterAsync(input);
    return StatusCode(result.StatusCode, result);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> LoginByEmailPasswordAsync([FromBody] LoginByEmailPasswordDto input)
  {
    var result = await service.LoginByEmailPasswordAsync(input);
    return StatusCode(result.StatusCode, result);
  }

  [HttpGet("[action]")]
  public async Task<string> Decript(string encript)
  {
    var result = await service.Decript(encript);
    return result;
  }

  [Authorize]
  [HttpGet("[action]")]
  public async Task<string> Test()
  {
    return "True";
  }
}
