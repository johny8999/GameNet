using Domain;
using Domain.Models;
using Domain.Models.MainModel;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

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
}
