using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblDebt : BaseModel
{
  public long CustomerId { get; set; }
  public decimal DebtAmount { get; set; }
  public Guid EntityId { get; set; }
}
