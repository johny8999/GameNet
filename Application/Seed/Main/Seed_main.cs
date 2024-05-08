using Application.Seed.Role;
using Application.Seed.User;
using Application.Seed.UserRole;

namespace Application.Seed.Main
{
  public class SeedMain : ISeedMain
  {
    private readonly ISeedRoles _seedRoles;
    private readonly ISeedUser _seedUser;
    private readonly ISeedUserRole _seedUserRole;

    public SeedMain(ISeedRoles seedRoles, ISeedUser seedUser, ISeedUserRole seedUserRole)
    {
      _seedRoles = seedRoles;
      _seedUser = seedUser;
      _seedUserRole = seedUserRole;
    }

    public async Task<bool> RunAsync()
    {
      try
      {
        await _seedRoles.RunAsync();
        await _seedUser.RunAsync();
        await _seedUserRole.RunAsync();
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}
