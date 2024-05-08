using Application.Seed.User;
using Domain.Models;
using FrameWork.Exceptions;
using FrameWork.ExMethods;
using Infra.Data.Repositories.UserRole;
using Infra.Data.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Seed.UserRole;

public class SeedUserRole : ISeedUserRole
{
  private readonly IUserRoleRepository _userRoleRepository;

  public SeedUserRole(IUserRoleRepository userRoleRepository)
  {
    _userRoleRepository = userRoleRepository;
  }

  public async Task<bool> RunAsync()
  {
    try
    {
      #region Admin

      {
        if (!await _userRoleRepository.GetNoTraking.AnyAsync(a =>
              a.RoleId == "ef23660b-8344-4243-8276-576845a1b262".ToGuid()))
          await _userRoleRepository.AddAsync(new TblUserRole()
          {
            RoleId = "ef23660b-8344-4243-8276-576845a1b262".ToGuid(),
            UserId = "ef23660b-8344-4243-8276-576845a1b262".ToGuid()
          });
      }

      #endregion Admin

      return true;
    }
    catch (ArgumentInvalidException ex)
    {
      // _Logger.Debug(ex);
      return default; //false
    }
    catch (Exception ex)
    {
      // _Logger.Error(ex);
      return default;
    }
  }
}
