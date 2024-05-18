using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblSubEntity : BaseModel
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public Guid EntityId { get; set; }

  [ForeignKey("EntityId")]
  public virtual TblEntity TblEntity { get; set; }
  public ICollection<TblDebt> TblDebts { get; set; }
  public virtual ICollection<TblSubEntityGameNet> TblSubEntityGameNets { get; set; }
}
