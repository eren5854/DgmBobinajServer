using DgmBobinajServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DgmBobinajServer.Configurations;

public sealed class InformationConfiguration : IEntityTypeConfiguration<Information>
{
    public void Configure(EntityTypeBuilder<Information> builder)
    {
        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder
            .Property(p => p.Phone)
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasMaxLength(11);

        builder
            .Property(p => p.Fax)
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasMaxLength(11);

        builder
            .Property(p => p.Address)
            .IsRequired()
            .HasColumnType("varchar(500)")
            .HasMaxLength(500);

        builder
            .Property(p => p.Email)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.HasQueryFilter(filter => !filter.IsDeleted);

    }
}
