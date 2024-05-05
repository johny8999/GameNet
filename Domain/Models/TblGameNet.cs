using Domain.Models.MainModel;

namespace Domain.Models;

public class TblGameNet:BaseModel
{
  public string Name { get; set; }
  public long CityId { get; set; }
}
