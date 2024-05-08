using Domain.Models;
using FrameWork.Exceptions;
using FrameWork.ExMethods;
using Infra.Data.Repositories.Roles;
using Microsoft.EntityFrameworkCore;

namespace Application.Seed.Role;

public class SeedRoles : ISeedRoles
{
  private readonly IRoleRepository _roleRepository;

  public SeedRoles(IRoleRepository roleRepository)
  {
    _roleRepository = roleRepository;
  }


  public async Task<bool> RunAsync()
  {
    try
    {
      #region AdminPage

      {
        if (!await _roleRepository.GetNoTraking.AnyAsync(a => a.ConcurrencyStamp == "AdminPage"))
          await _roleRepository.AddAsync(new TblRole()
          {
            Id = "ef23660b-8344-4243-8276-576845a1b262".ToGuid(),
            Name = "مدیر سایت",
            NormalizedName = "AdminPage".ToUpper(),
            ConcurrencyStamp = "AdminPage"
          });
      }

      #endregion AdminPage

      #region Seller

      {
        if (!await _roleRepository.GetNoTraking.AnyAsync(a => a.ConcurrencyStamp == "Seller"))
          await _roleRepository.AddAsync(new TblRole()
          {
            Id = "ef23660b-8344-4243-8276-576845a1b263".ToGuid(),
            Name = "فروشنده",
            NormalizedName = "Seller".ToUpper(),
            ConcurrencyStamp = "Seller"
          });
      }

      #endregion AdminPage

      #region Seller

      {
        if (!await _roleRepository.GetNoTraking.AnyAsync(a => a.ConcurrencyStamp == "Customer"))
          await _roleRepository.AddAsync(new TblRole()
          {
            Id = "ef23660b-8344-4243-8276-576845a1b264".ToGuid(),
            Name = "مشتری",
            NormalizedName = "Customer".ToUpper(),
            ConcurrencyStamp = "Customer"
          });
      }

      #endregion AdminPage

      #region Apprentice shop

      {
        if (!await _roleRepository.GetNoTraking.AnyAsync(a => a.ConcurrencyStamp == "ApprenticeShop"))
          await _roleRepository.AddAsync(new TblRole()
          {
            Id = "ef23660b-8344-4243-8276-576845a1b265".ToGuid(),
            Name = "شاگرد",
            NormalizedName = "ApprenticeShop".ToUpper(),
            ConcurrencyStamp = "ApprenticeShop"
          });
      }

      #endregion Apprentice shop

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
