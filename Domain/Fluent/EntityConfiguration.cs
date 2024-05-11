using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class EntityConfiguration:IEntityTypeConfiguration<TblEntity>
{
  public void Configure(EntityTypeBuilder<TblEntity> builder)
  {
    builder.HasKey(a => a.Id);
    builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
    builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
  }
}
