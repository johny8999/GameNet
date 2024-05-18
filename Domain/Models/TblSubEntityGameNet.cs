using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblSubEntityGameNet : BaseModel
{
  public decimal Price { get; set; }
  public DateOnly DatePrice { get; set; }
  public Guid GameNetId { get; set; }
  public Guid SubEntityId { get; set; }



  [ForeignKey("GameNetId")]
  public TblGameNet TblGameNet { get; set; }
    [ForeignKey("SubEntityId")]
  public TblSubEntity TblSubEntity { get; set; }

}
