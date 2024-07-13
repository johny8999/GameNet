
using Application.Dto.UserRole.Request;


namespace Template.Controllers;

public class UserRoleController(IUserRoleApplication service) : ControllerBase
{
  [HttpPost("[action]")]
  [AllowAnonymous]
  [Authorize(Roles = ConstNames.Adminpage)]
  [Authorize(Roles = ConstNames.Seller)]
  public async Task<IActionResult> ChangeUserRoleAsync([FromBody] ChangeUserRole input)
  {
    var result = await service.ChangeUserRoleAsync(input);
    return StatusCode(result.StatusCode, result);
  }

  [HttpPost("[action]")]
  [AllowAnonymous]
  [Authorize(Roles = ConstNames.Adminpage)]
  [Authorize(Roles = ConstNames.Seller)]
  public async Task<IActionResult> AddUserRoleAsync([FromBody] AddUserRoleDto input)
  {
    var result = await service.AddUserRoleAsync(input);
    return StatusCode(result.StatusCode, result);
  }
}
