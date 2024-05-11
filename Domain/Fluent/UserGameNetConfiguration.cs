using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Fluent;

public class UserGameNetConfiguration:IEntityTypeConfiguration<TblUserGameNet>
{
  public void Configure(EntityTypeBuilder<TblUserGameNet> builder)
  {
    builder.HasKey(a => a.Id);
    builder.Property(a => a.Id).IsRequired().HasMaxLength(150);


    builder.HasOne(a => a.TblGameNet)
      .WithMany(a => a.TblUserGameNet)
      .HasPrincipalKey(a => a.Id)
      .HasForeignKey(a => a.GameNetID)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(a => a.TblUser)
      .WithMany(a => a.TblUserGameNets)
      .HasPrincipalKey(a => a.Id)
      .HasForeignKey(a => a.UserId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
