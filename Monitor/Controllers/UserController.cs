using Application.Dto;
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
  public async Task<IActionResult> GetShiftOperationByInputCount(RegisterDTo input)
  {
    var result = await _service.RegisterAsync(input);
    return StatusCode(result.StatusCode, result);
  }
}
