using Application.Dto.UserRole.Request;

namespace Template.Controllers;

public class UserRoleController(IUserRoleApplication service) : ControllerBase
{
  [HttpPost("[action]")]
  public async Task<IActionResult> ChangeUserRoleAsync([FromBody] ChangeUserRole input)
  {
       var result = await service.ChangeUserRoleAsync(input);
      return StatusCode(result.StatusCode, result);
  }
}
