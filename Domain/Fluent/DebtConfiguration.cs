using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class DebtConfiguration:IEntityTypeConfiguration<TblDebt>
{
  public void Configure(EntityTypeBuilder<TblDebt> builder)
  {
    builder.HasKey(a => a.Id);
    builder.Property(a => a.Id).IsRequired().HasMaxLength(150);

    builder.HasOne(a => a.TblUser)
      .WithMany(a => a.TblDebts)
      .HasPrincipalKey(a => a.Id)
      .HasForeignKey(a => a.UserId)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(a => a.TblSubEntity)
      .WithMany(a => a.TblDebts)
      .HasPrincipalKey(a => a.Id)
      .HasForeignKey(a => a.SubEntityId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
