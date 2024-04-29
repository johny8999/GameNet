using Domain.Models.MainModel;

namespace Domain.Models;

public class EntityGameNet : BaseModel
{
  public long GameNetId { get; set; }
  public long EntityId { get; set; }
}
