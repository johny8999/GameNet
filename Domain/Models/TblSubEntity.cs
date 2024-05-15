using System;
using System.Collections.Generic;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblSubEntity : BaseModel
{
  public string Name { get; set; }
  public decimal Price { get; set; }

  public virtual TblEntity TblEntity { get; set; }
  public ICollection<TblDebt> TblDebts { get; set; }
  public virtual ICollection<TblSubEntityGameNet> TblSubEntityGameNets { get; set; }
}
