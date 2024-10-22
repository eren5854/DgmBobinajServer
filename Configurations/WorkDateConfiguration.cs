using DgmBobinajServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DgmBobinajServer.Configurations;

public sealed class WorkDateConfiguration : IEntityTypeConfiguration<WorkDate>
{
    public void Configure(EntityTypeBuilder<WorkDate> builder)
    {
        builder
            .Property(p => p.Day)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);

        builder.HasQueryFilter(filter => !filter.IsDeleted);

    }
}
