using System;
using System.Collections.Generic;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblSubEntity : BaseModel
{
  public string Name { get; set; }

  public Guid EntityId { get; set; }

  public virtual TblEntity TblEntity { get; set; }
  public ICollection<TblSubEntityGameNet> TblSubEntityGameNets { get; set; }
  public ICollection<TblDebt> TblDebts { get; set; }
}
