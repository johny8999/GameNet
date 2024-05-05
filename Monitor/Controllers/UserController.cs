using Application.Dto;
using Application.Dto.Users.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers;

public class UserController : ControllerBase
{
  private readonly IUserApplication _service;

  public UserController(IUserApplication service)
  {
    _service = service;
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTo input)
  {
    var result = await _service.RegisterAsync(input);
    return StatusCode(result.StatusCode, result);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> LoginByEmailPasswordAsync([FromBody] LoginByEmailPasswordDto input)
  {
    var result = await _service.LoginByEmailPasswordAsync(input);
    return StatusCode(result.StatusCode, result);
  }
}
