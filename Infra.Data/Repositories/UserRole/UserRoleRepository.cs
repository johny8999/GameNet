using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.UserRole;

public class UserRoleRepository:Repository<TblUserRole>,IUserRoleRepository
{
  public UserRoleRepository(MainContext context) : base(context)
  {
  }
}
