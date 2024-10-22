using DgmBobinajServer.Models;
using ED.GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Context;

public sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Layout> Layouts { get; set; }
    public DbSet<Link> Links { get; set; }
    public DbSet<MiniService> MiniServices { get; set; }
    public DbSet<DescriptionModel> DescriptionModels { get; set; }


    public DbSet<About> Abouts { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Process> Processs { get; set; }
    public DbSet<Galery> Galeries { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<WorkDate> WorkDates { get; set; }
    public DbSet<Information> Informations { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
