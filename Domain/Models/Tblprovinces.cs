using System.Collections.Generic;
using Domain.Models.MainModel;

namespace Domain.Models;

public class Tblprovinces : BaseModel
{
  public string Name { get; set; }

  public virtual ICollection<TblCity> TblCities { get; set; }
}
