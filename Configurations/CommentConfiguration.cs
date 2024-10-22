using DgmBobinajServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DgmBobinajServer.Configurations;

public sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .Property(p => p.CommentName)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder
            .Property(p => p.CommentText)
            .IsRequired()
            .HasColumnType("varchar(2000)")
            .HasMaxLength(2000);

        builder
            .Property(p => p.Rate)
            .IsRequired()
            .HasColumnType("int")
            .HasMaxLength(5);

        builder.HasQueryFilter(filter => !filter.IsDeleted);

    }
}
