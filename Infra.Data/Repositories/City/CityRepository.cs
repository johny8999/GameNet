using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.City;

public class CityRepository(MainContext context) : Repository<TblCity>(context), ICityRepository;
