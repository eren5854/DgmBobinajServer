using DgmBobinajServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DgmBobinajServer.Configurations;

public sealed class MiniServiceConfiguration : IEntityTypeConfiguration<MiniService>
{
    public void Configure(EntityTypeBuilder<MiniService> builder)
    {
        builder
           .Property(p => p.Title)
           .IsRequired()
           .HasColumnType("varchar(50)")
           .HasMaxLength(50);

        builder
            .Property(p => p.Subtitle)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
