using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class SubEntityConfiguration : IEntityTypeConfiguration<TblSubEntity>
{
  public void Configure(EntityTypeBuilder<TblSubEntity> builder)
  {
    builder.Property(a => a.Name).IsRequired().HasMaxLength(50);

    builder.HasOne(a => a.TblEntity)
      .WithMany(a => a.TblSubEntities)
      .HasPrincipalKey(a => a.Id)
      .HasForeignKey(a => a.Id)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
