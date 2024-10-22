using DgmBobinajServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DgmBobinajServer.Configurations;

public sealed class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
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
            .Property(p => p.Email)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder
            .Property(p => p.Subject)
            .IsRequired()
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);

        builder
            .Property(p => p.Content)
            .IsRequired()
            .HasColumnType("varchar(3000)")
            .HasMaxLength(3000);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
