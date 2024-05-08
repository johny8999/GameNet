using Application.Dto.Role.Request;
using Application.Interfaces;
using FrameWork.ExMethods;
using Infra.Data.Repositories.Roles;
using Infra.Data.Repositories.UserRole;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class RoleApplication : IRoleApplication
{
  private readonly IUserRoleRepository _userRoleRepository;
  private readonly IRoleRepository _roleRepository;

  public RoleApplication(IUserRoleRepository userRoleRepository, IRoleRepository roleRepository)
  {
    _userRoleRepository = userRoleRepository;
    _roleRepository = roleRepository;
  }

  public async Task<List<string>> GetRoleNameByUserIdAsync(GetRoleNameByUserIdDto input)
  {
    try
    {
      var userRole = _userRoleRepository.Get
        .Where(a => a.UserId == input.UserId.ToGuid()).AsQueryable();

      if (userRole is not null)
      {
        var role = await _roleRepository.Get.Where(a => userRole.Any(b => a.Id == b.RoleId))
          .Select(a => a.Name)
          .ToListAsync();
        return role;
      }

      return new List<string>();
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }
}
