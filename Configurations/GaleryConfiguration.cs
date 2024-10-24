using DgmBobinajServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DgmBobinajServer.Configurations;

public sealed class GaleryConfiguration : IEntityTypeConfiguration<Galery>
{
    public void Configure(EntityTypeBuilder<Galery> builder)
    {
        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
