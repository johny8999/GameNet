using Domain.Models.MainModel;

namespace Domain.Models;

public class Customer:BaseModel
{
  public long UserId { get; set; }
  public long GameNetId { get; set; }
}
