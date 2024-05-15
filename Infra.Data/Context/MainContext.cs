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


  public DbSet<TblUsers> Users { get; set; }
  public DbSet<TblCity> City { get; set; }
  public DbSet<TblCustomerAccounting> CustomerAccounting { get; set; }
  public DbSet<TblDebt> Debt { get; set; }
  public DbSet<TblEntity> Entity { get; set; }
  public DbSet<TblSubEntityGameNet> EntityGameNet { get; set; }
  public DbSet<TblGameNet> GameNet { get; set; }
  public DbSet<Tblprovinces> Provinces { get; set; }
  public DbSet<TblUserGameNet> TblUserGameNet { get; set; }
  public DbSet<TblSubEntity> TblSubEntity { get; set; }
}
