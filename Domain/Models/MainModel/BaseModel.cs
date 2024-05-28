using System;
using FrameWork.ExMethods;

namespace Domain.Models.MainModel
{
  public class BaseModel
  {
    public Guid Id { get; set; } = new Guid().SequentialGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; }
  }
}
