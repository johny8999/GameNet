using Application.Dto.UserRole.Request;

namespace Template.Controllers;

public class UserRoleController(IUserRoleApplication service) : ControllerBase
{
  [HttpPost("[action]")]
  public async Task<IActionResult> ChangeRoleAsync([FromBody] ChangeRoleDto input)
  {
       var result = await service.ChangeRoleAsync(input);
      return StatusCode(result.StatusCode, result);
  }
}
