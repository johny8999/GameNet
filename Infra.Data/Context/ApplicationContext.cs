using Domain.Models;
using Domain.Models.OperationTables;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }


    public DbSet<Order_Operation> Order_Operation { get; set; }
    public DbSet<Pallet_Operation> Pallet_Operation { get; set; }
    public DbSet<Shift_Operation> Shift_Operation { get; set; }
    public DbSet<User_Operation> User_Operation { get; set; }
    public DbSet<WorkCenter_Operation> WorkCenter_Operation { get; set; }
    public DbSet<Production> Production { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //   base.OnConfiguring(optionsBuilder);
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}
