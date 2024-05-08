using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblSubEntity : BaseModel
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public Guid EntityId { get; set; }

  public virtual TblEntity TblEntity { get; set; }
}
