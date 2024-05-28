using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblCustomerAccounting : BaseModel
{
  public decimal Purchase { get; set; }
  public DateTime PurchaseDate { get; set; }
  public Guid UserId { get; set; }
  public Guid SubEntityGameNetId { get; set; }

  [ForeignKey("UserId")] public TblUsers TblUser { get; set; }
  [ForeignKey("SubEntityGameNetId")] public TblSubEntityGameNet TblSubEntityGameNet { get; set; }
}
