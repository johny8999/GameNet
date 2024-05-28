using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.CustomerAccounting;

public class CustomerAccountingRepository(MainContext context)
  : Repository<TblCustomerAccounting>(context), ICustomerAccountingRepository;
