using Domain.Models.MainModel;

namespace Domain.Models;

public class TblCity : BaseModel
{
  public string Name { get; set; }
  public long ProvincesId { get; set; }
}
