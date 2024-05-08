using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblGameNetCustomer:BaseModel
{
  public Guid CustomerId { get; set; }
  public Guid GameNetId { get; set; }
}
