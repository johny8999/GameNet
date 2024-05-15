using System;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblUserGameNet : BaseModel
{
  public TblUsers TblUser { get; set; }
  public TblGameNet TblGameNet { get; set; }
}
