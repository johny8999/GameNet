using Application.Seed.Entity;
using Application.Seed.Role;
using Application.Seed.User;
using Application.Seed.UserRole;

namespace Application.Seed.Main
{
  public class SeedMain(ISeedRoles seedRoles, ISeedUser seedUser, ISeedUserRole seedUserRole, ISeedEntity seedEntity)
    : ISeedMain
  {
    public async Task<bool> RunAsync()
    {
      try
      {
        var task = await Task.WhenAll(
          seedRoles.RunAsync(),
          seedUser.RunAsync(),
          seedUserRole.RunAsync(),
          seedUserRole.RunAsync(),
          seedEntity.RunAsync()
        );
        var allTasksCompleted = task.All(a => a == true) ?  true : false;

        return allTasksCompleted;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}
