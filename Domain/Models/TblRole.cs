using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public class TblRole:IdentityRole<Guid>
{
  public virtual ICollection<TblUserGameNet> TblRoleGameNet { get; set; }
}
