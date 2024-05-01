using Domain.Models.MainModel;

namespace Domain.Models;

public class GameNetCustomer:BaseModel
{
  public long CustomerId { get; set; }
  public long GameNetId { get; set; }
}
