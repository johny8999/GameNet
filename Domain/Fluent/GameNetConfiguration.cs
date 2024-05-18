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
    builder.Property(a => a.Name).IsRequired().HasMaxLength(50);


    // builder.HasOne(a => a.TblCity)
    //   .WithMany(a => a.TblGameNet)
    //   .HasPrincipalKey(a => a.Id)
    //   .HasForeignKey(a => a.TblCity.Id)
    //   .OnDelete(DeleteBehavior.Restrict);
  }
}
