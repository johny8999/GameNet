using Application.Dto.Role.Request;
using Application.Interfaces;
using FrameWork.ExMethods;
using Infra.Data.Repositories.UserRole;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class RoleApplication : IRoleApplication
{
  private readonly IUserRoleRepository _UserRoleRepository;

  public RoleApplication(IUserRoleRepository userRoleRepository)
  {
    _UserRoleRepository = userRoleRepository;
  }

  public async Task<List<string>> GetRoleNameByUserIdAsync(GetRoleNameByUserIdDto input)
  {
    try
    {
      return (await _UserRoleRepository.GetNoTraking
        .Where(a => a.UserId == input.UserId.ToGuid())
        .Select(a => a.tblRoles.Name)
        .ToListAsync())!;
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }
}
