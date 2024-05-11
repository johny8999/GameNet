using System;
using System.Collections.Generic;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblSubEntityGameNet : BaseModel
{
  public decimal Price { get; set; }
  public DateOnly DatePrice { get; set; }
  public Guid GameNetId { get; set; }
  public Guid SubEntityId { get; set; }

  public TblGameNet TblGameNet { get; set; }
  public TblSubEntity TblSubEntity { get; set; }

}
