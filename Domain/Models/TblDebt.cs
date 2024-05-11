using System;
using System.Collections.Generic;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblDebt : BaseModel
{
  public Guid UserId { get; set; }
  public decimal DebtAmount { get; set; }
  public Guid SubEntityId { get; set; }
  public DateTime DateDebt { get; set; }


  public TblUsers TblUser { get; set; }
  public TblSubEntity TblSubEntity { get; set; }

  public ICollection<TblCustomerAccounting> TblCustomerAccountings { get; set; }
}
