using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Entity;

public class EntityRepository : Repository<TblEntity>, IEntityRepository
{
  public EntityRepository(MainContext context) : base(context)
  {
  }
}
