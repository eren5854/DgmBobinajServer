using DgmBobinajServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DgmBobinajServer.Configurations;

public sealed class DescriptionModelConfiguration : IEntityTypeConfiguration<DescriptionModel>
{
    public void Configure(EntityTypeBuilder<DescriptionModel> builder)
    {
        builder
            .Property(p => p.Title)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder
            .Property(p => p.Text)
            .IsRequired()
            .HasColumnType("varchar(2000)")
            .HasMaxLength(2000);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
