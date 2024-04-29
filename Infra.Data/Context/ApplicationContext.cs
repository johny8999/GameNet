using Domain;
using Domain.Models;
using Domain.Models.MainModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public class ApplicationContext : IdentityDbContext<Users, Roles, long, IdentityUserClaim<long>, UserRoles,
  IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
{
  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
  {
  }

  public ApplicationContext()
  {
  }

  public DbSet<Users> Users { get; set; }
  public DbSet<Roles> Roles { get; set; }
  public DbSet<UserRoles> UserRoles { get; set; }
  public DbSet<City> City { get; set; }
  public DbSet<Customer> Customer { get; set; }
  public DbSet<CustomerAccounting> CustomerAccounting { get; set; }
  public DbSet<Debt> Debt { get; set; }
  public DbSet<Entity> Entity { get; set; }
  public DbSet<EntityGameNet> EntityGameNet { get; set; }
  public DbSet<GameNet> GameNet { get; set; }
  public DbSet<GameNetSeller> GameNetSeller { get; set; }
  public DbSet<Provinces> Provinces { get; set; }
  public DbSet<Seller> Seller { get; set; }
}
