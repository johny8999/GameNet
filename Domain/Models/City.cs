using Domain.Models.MainModel;

namespace Domain.Models;

public class City : BaseModel
{
  public string Name { get; set; }
  public long ProvincesId { get; set; }
}
