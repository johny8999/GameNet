using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class GameNetConfiguration : IEntityTypeConfiguration<TblGameNet>
{
  public void Configure(EntityTypeBuilder<TblGameNet> builder)
  {
    builder.HasKey(a => a.Id);
    builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
    builder.Property(a => a.CityId).IsRequired().HasMaxLength(150);
    builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
  }
}
