using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class SubEntityGameNetConfiguration:IEntityTypeConfiguration<TblSubEntityGameNet>
{
  public void Configure(EntityTypeBuilder<TblSubEntityGameNet> builder)
  {
    builder.HasKey(a => a.Id);
    builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
    builder.Property(a => a.GameNetId).IsRequired().HasMaxLength(150);
    builder.Property(a => a.SubEntityId).IsRequired().HasMaxLength(150);


    builder.HasOne(a => a.TblGameNet)
      .WithMany(a => a.TblSubEntityGameNets)
      .HasPrincipalKey(a => a.Id)
      .HasForeignKey(a => a.SubEntityId)
      .OnDelete(DeleteBehavior.Restrict);


    builder.HasOne(a => a.TblGameNet)
      .WithMany(a => a.TblSubEntityGameNets)
      .HasPrincipalKey(a => a.Id)
      .HasForeignKey(a => a.SubEntityId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
