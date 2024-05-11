using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblCustomerAccounting : BaseModel
{
  public decimal DailyPurchase { get; set; }
  public Guid UserId { get; set; }
  public Guid DebtId { get; set; }


  public TblUsers TblUser { get; set; }
  public TblDebt TblDebt { get; set; }
}
