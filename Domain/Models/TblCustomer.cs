using Domain.Models.MainModel;

namespace Domain.Models;

public class TblCustomer:BaseModel
{
  public long UserId { get; set; }
  public long GameNetId { get; set; }
}
