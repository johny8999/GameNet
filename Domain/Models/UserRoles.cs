using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public class UserRoles : IdentityUserRole<long>
{
  public long Id { get; set; }

  public virtual Users Users { get; set; }
  public virtual Roles Roles { get; set; }
}
