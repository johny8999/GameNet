using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class UserConfiguration : IEntityTypeConfiguration<TblUsers>
{
  public void Configure(EntityTypeBuilder<TblUsers> builder)
  {
    builder.HasKey(a => a.Id);
    builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
    builder.Property(a => a.FirstName).IsRequired(false).HasMaxLength(100);
    builder.Property(a => a.LastName).IsRequired(false).HasMaxLength(100);
    builder.Property(a => a.NationalCode).IsRequired(false).HasMaxLength(100);
  }
}
