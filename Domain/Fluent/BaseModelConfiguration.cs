using Domain.Models.MainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class BaseModelConfiguration : IEntityTypeConfiguration<BaseModel>
{
  public void Configure(EntityTypeBuilder<BaseModel> builder)
  {
    builder.HasKey(a => a.ID);
    builder.Property(a => a.ID).ValueGeneratedOnAdd();
  }
}