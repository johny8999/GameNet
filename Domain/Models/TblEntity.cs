using System.Collections.Generic;
using Domain.Models.MainModel;

namespace Domain.Models;

public class TblEntity:BaseModel
{
  public string Name { get; set; }


  public virtual ICollection<TblSubEntity> TblSubEntities { get; set; }
}
