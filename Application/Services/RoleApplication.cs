using System.Net;
using Application.Common.Responses;
using Application.Common.Statics;
using Application.Dto.Role.Request;
using Application.Interfaces;
using FrameWork.ExMethods;
using FrameWork.Services;
using Infra.Data.Repositories.Roles;
using Infra.Data.Repositories.UserRole;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class RoleApplication : IRoleApplication
{
  private readonly IUserRoleRepository _userRoleRepository;
  private readonly IRoleRepository _roleRepository;
  private readonly ISerilogger _serilogger;
  private readonly IResponse _response;

  public RoleApplication(IUserRoleRepository userRoleRepository, IRoleRepository roleRepository, ISerilogger serilogger,
    IResponse response)
  {
    _userRoleRepository = userRoleRepository;
    _roleRepository = roleRepository;
    _serilogger = serilogger;
    _response = response;
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
      _serilogger.Error(e);
      return new List<string>();
    }
  }
}
