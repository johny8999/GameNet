using Infra.Data.Repositories.Roles;

namespace Application.Seed.Role;

public class SeedRoles : ISeedRoles
{
  private readonly IRoleRepository _roleRepository;
  private readonly ISerilogger _serilogger;

  public SeedRoles(IRoleRepository roleRepository, ISerilogger serilogger)
  {
    _roleRepository = roleRepository;
    _serilogger = serilogger;
  }


  public async Task<bool> RunAsync()
  {
    try
    {
      List<bool> allSaveList = new();

      #region AdminPage

      {
        if (!await _roleRepository.GetNoTraking.AnyAsync(a => a.ConcurrencyStamp!.ToLower() == "AdminPage".ToLower()))
        {
          await _roleRepository.AddAsync(new TblRole()
          {
            Id = "ef23660b-8344-4243-8276-576845a1b262".ToGuid(),
            Name = "مدیر سایت",
            NormalizedName = "AdminPage".ToUpper(),
            ConcurrencyStamp = "AdminPage"
          });
          allSaveList.Add(true);
        }
      }
      allSaveList.Add(false);

      #endregion AdminPage

      #region Seller

      {
        if (!await _roleRepository.GetNoTraking.AnyAsync(a => a.ConcurrencyStamp!.ToLower() == "Seller".ToLower()))
        {
          await _roleRepository.AddAsync(new TblRole()
          {
            Id = "ef23660b-8344-4243-8276-576845a1b263".ToGuid(),
            Name = "فروشنده",
            NormalizedName = "Seller".ToUpper(),
            ConcurrencyStamp = "Seller"
          });
          allSaveList.Add(true);
        }
      }
      allSaveList.Add(false);

      #endregion AdminPage

      #region Customer

      {
        if (!await _roleRepository.GetNoTraking.AnyAsync(a => a.ConcurrencyStamp!.ToLower() == "Customer".ToLower()))
        {
          await _roleRepository.AddAsync(new TblRole()
          {
            Id = "ef23660b-8344-4243-8276-576845a1b264".ToGuid(),
            Name = "مشتری",
            NormalizedName = "Customer".ToUpper(),
            ConcurrencyStamp = "Customer"
          });
          allSaveList.Add(true);
        }
      }
      allSaveList.Add(false);

      #endregion AdminPage

      #region Apprentice shop

      {
        if (!await _roleRepository.GetNoTraking.AnyAsync(a =>
              a.ConcurrencyStamp!.ToLower() == "ApprenticeShop".ToLower()))
        {
          await _roleRepository.AddAsync(new TblRole()
          {
            Id = "ef23660b-8344-4243-8276-576845a1b265".ToGuid(),
            Name = "شاگرد",
            NormalizedName = "ApprenticeShop".ToUpper(),
            ConcurrencyStamp = "ApprenticeShop"
          });
          allSaveList.Add(true);
        }
      }
      allSaveList.Add(false);

      #endregion Apprentice shop

      var allTasksCompleted = allSaveList.All(a => a);
      return allTasksCompleted;
    }
    catch (ArgumentInvalidException ex)
    {
      _serilogger.Debug(ex);
      return false;
    }
    catch (Exception ex)
    {
      _serilogger.Error(ex);
      return false;
    }
  }
}
