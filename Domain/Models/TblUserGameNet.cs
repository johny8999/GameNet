using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblUserGameNet : BaseModel
{
    public Guid UserId { get; set; }
    public Guid GameNetId { get; set; }

  [ForeignKey("UserId")]
  public TblUsers TblUser { get; set; }
    [ForeignKey("GameNetId")]
  public TblGameNet TblGameNet { get; set; }
}
