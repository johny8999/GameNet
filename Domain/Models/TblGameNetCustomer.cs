using Domain.Models.MainModel;

namespace Domain.Models;

public class TblGameNetCustomer:BaseModel
{
  public long CustomerId { get; set; }
  public long GameNetId { get; set; }
}
