using Domain.Models.MainModel;

namespace Domain.Models;

public class TblEntityGameNet : BaseModel
{
  public long GameNetId { get; set; }
  public long EntityId { get; set; }
}
