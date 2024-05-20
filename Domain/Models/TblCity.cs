using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblCity : BaseModel
{
  public string Name { get; set; }
  public Guid ProvincesId { get; set; }

  [ForeignKey("ProvincesId")] public Tblprovinces Tblprovinces { get; set; }
  public virtual ICollection<TblGameNet> TblGameNet { get; set; }
}
