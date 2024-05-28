using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.GameNet;

public class GameNetRepository(MainContext context) : Repository<TblGameNet>(context), IGameNetRepository;
