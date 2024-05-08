using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblEntityGameNet : BaseModel
{
  public Guid GameNetId { get; set; }
  public Guid EntityId { get; set; }
}
