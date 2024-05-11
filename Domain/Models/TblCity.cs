using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblCity : BaseModel
{
  public string Name { get; set; }
  public Guid ProvincesId { get; set; }

  public  Tblprovinces Tblprovinces { get; set; }
}
