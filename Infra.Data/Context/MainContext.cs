using System;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public class MainContext : IdentityDbContext<TblUsers, TblRole, Guid, IdentityUserClaim<Guid>, TblUserRole,
  IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
  public MainContext(DbContextOptions<MainContext> options) : base(options)
  {
  }

  public MainContext()
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
  }

  public DbSet<TblUsers> Users { get; set; }
  public DbSet<TblCity> City { get; set; }
  public DbSet<TblCustomer> Customer { get; set; }
  public DbSet<TblCustomerAccounting> CustomerAccounting { get; set; }
  public DbSet<TblDebt> Debt { get; set; }
  public DbSet<TblEntity> Entity { get; set; }
  public DbSet<TblEntityGameNet> EntityGameNet { get; set; }
  public DbSet<TblGameNet> GameNet { get; set; }
  public DbSet<TblGameNetCustomer> GameNetSeller { get; set; }
  public DbSet<Tblprovinces> Provinces { get; set; }
  public DbSet<TblSeller> Seller { get; set; }
}
