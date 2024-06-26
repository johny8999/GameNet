using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class CityConfiguration:IEntityTypeConfiguration<TblCity>
{
  public void Configure(EntityTypeBuilder<TblCity> builder)
  {
    builder.HasKey(a => a.Id);
    builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
    builder.Property(a => a.Name).IsRequired().HasMaxLength(50);

    // builder.HasOne(a => a.Tblprovinces)
    //   .WithMany(a => a.TblCities)
    //   .HasPrincipalKey(a => a.Id)
    //   .HasForeignKey(a => a.Id)
    //   .OnDelete(DeleteBehavior.Restrict);
  }
}
