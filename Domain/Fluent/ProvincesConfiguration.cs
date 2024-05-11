using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class ProvincesConfiguration:IEntityTypeConfiguration<Tblprovinces>
{

  public void Configure(EntityTypeBuilder<Tblprovinces> builder)
  {
    builder.HasKey(a => a.Id);
    builder.Property(a => a.Id).IsRequired().HasMaxLength(150);


  }
}
