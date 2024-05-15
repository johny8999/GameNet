using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.SubEntity;

public class SubEntityRepository : Repository<TblSubEntity>, ISubEntityRepository
{
  public SubEntityRepository(MainContext context) : base(context)
  {
  }
}
