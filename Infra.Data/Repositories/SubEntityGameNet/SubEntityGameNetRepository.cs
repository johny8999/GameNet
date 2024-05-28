using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.SubEntityGameNet;

public class SubEntityGameNetRepository(MainContext context)
      : Repository<TblSubEntityGameNet>(context), ISubEntityGameNetRepository;

