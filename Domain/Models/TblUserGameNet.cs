using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblUserGameNet : BaseModel
{
  public Guid UserId { get; set; }
  public Guid GameNetID { get; set; }


  public TblUsers TblUser { get; set; }
  public TblGameNet TblGameNet { get; set; }
}
