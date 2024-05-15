using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.GameNet;

public class GameNetRepository: Repository<TblGameNet>, IGameNetRepository
{
  public GameNetRepository(MainContext context) : base(context)
  {
  }
}
