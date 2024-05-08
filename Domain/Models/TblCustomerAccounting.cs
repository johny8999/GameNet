using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblCustomerAccounting : BaseModel
{
  public decimal DailyPurchase { get; set; }
  public Guid CustomerId { get; set; }
  public Guid DebtId { get; set; }
}
