using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Roles;

public class RoleRepository : Repository<TblRole>, IRoleRepository
{
  public RoleRepository(MainContext context) : base(context)
  {
  }
}
