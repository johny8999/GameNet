using Domain.Models.MainModel;

namespace Domain.Models;

public class CustomerAccounting : BaseModel
{
  public decimal DailyPurchase { get; set; }
  public long CustomerId { get; set; }
  public long DebtId { get; set; }
}
