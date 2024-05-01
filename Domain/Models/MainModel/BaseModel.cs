using System;

namespace Domain.Models.MainModel
{
  public class BaseModel
  {
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
  }
}
