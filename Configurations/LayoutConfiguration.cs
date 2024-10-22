using DgmBobinajServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DgmBobinajServer.Configurations;

public sealed class LayoutConfiguration : IEntityTypeConfiguration<Layout>
{
    public void Configure(EntityTypeBuilder<Layout> builder)
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
