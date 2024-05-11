using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class CustomerAccountingConfiguration:IEntityTypeConfiguration<TblCustomerAccounting>
{
  public void Configure(EntityTypeBuilder<TblCustomerAccounting> builder)
  {
    builder.HasKey(a => a.Id);
    builder.Property(a => a.Id).IsRequired().HasMaxLength(150);

    builder.HasOne(a => a.TblUser)
      .WithMany(a => a.TblCustomerAccountings)
      .HasPrincipalKey(a => a.Id)
      .HasForeignKey(a => a.UserId)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(a => a.TblDebt)
      .WithMany(a => a.TblCustomerAccountings)
      .HasPrincipalKey(a => a.Id)
      .HasForeignKey(a => a.UserId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
