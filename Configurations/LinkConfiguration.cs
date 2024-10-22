using DgmBobinajServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DgmBobinajServer.Configurations;

public sealed class LinkConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder
            .Property(p => p.Url)
            .IsRequired()
            .HasColumnType("varchar(300)")
            .HasMaxLength(300);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
