using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.City;

public class CityRepository: Repository<TblCity>, ICityRepository
{
  public CityRepository(MainContext context) : base(context)
  {
  }
}
