using DgmBobinajServer.Context;
using DgmBobinajServer.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Repositories;

public sealed class LinkRepository(ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Link link, CancellationToken cancellationToken)
    {
        await context.AddAsync(link, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Link kaydı başarılı");
    }

    public async Task<Result<List<Link>>> GetAll(CancellationToken cancellationToken)
    {
        var links = await context.Links.ToListAsync(cancellationToken);
        return Result<List<Link>>.Succeed(links);
    }

    public async Task<Result<List<Link>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var linls = await context.Links.Where(p => p.IsActive).ToListAsync(cancellationToken);
        return Result<List<Link>>.Succeed(linls);
    }

    public Link? GetById(Guid Id)
    {
        return context.Links.Where(p => p.Id == Id).FirstOrDefault();
    } 

    public async Task<Result<string>> Update(Link link, CancellationToken cancellationToken)
    {
        context.Update(link);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Link güncelleme başarılı");
    }

    public async Task<Result<string>> DeleteByıd(Guid Id, CancellationToken cancellation)
    {
        Link? link = GetById(Id);
        if (link is null)
        {
            return Result<string>.Failure("Link kaydı bulunamadı");

        }

        link.IsDeleted = true;
        context.Update(link);
        await context.SaveChangesAsync(cancellation);
        return Result<string>.Succeed("Link silme başarılı");
    }
}
