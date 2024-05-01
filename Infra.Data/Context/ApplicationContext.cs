using Domain;
using Domain.Models;
using Domain.Models.MainModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public class ApplicationContext : IdentityDbContext
{
  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
  {
  }

  public ApplicationContext()
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
  }

  public DbSet<Users> Users { get; set; }
  public DbSet<City> City { get; set; }
  public DbSet<Customer> Customer { get; set; }
  public DbSet<CustomerAccounting> CustomerAccounting { get; set; }
  public DbSet<Debt> Debt { get; set; }
  public DbSet<Entity> Entity { get; set; }
  public DbSet<EntityGameNet> EntityGameNet { get; set; }
  public DbSet<GameNet> GameNet { get; set; }
  public DbSet<GameNetCustomer> GameNetSeller { get; set; }
  public DbSet<Provinces> Provinces { get; set; }
  public DbSet<Seller> Seller { get; set; }
}
