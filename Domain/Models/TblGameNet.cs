using System;
using System.Collections.Generic;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblGameNet : BaseModel
{
  public string Name { get; set; }
  public Guid CityId { get; set; }


  public virtual ICollection<TblCustomer> TblCustomer { get; set; }
}
