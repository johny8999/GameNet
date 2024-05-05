using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public class TblUserRole : IdentityUserRole<Guid>
{
  public Guid Id { get; set; }

  public virtual TblUsers tblUsers { get; set; }
  public virtual TblRole tblRoles { get; set; }
}
