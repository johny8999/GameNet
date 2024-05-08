using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblCustomer : BaseModel
{
  public Guid UserId { get; set; }
  public Guid GameNetId { get; set; }

  public virtual TblUsers TblUsers { get; set; }
  public virtual TblGameNet TblGameNet { get; set; }
}
