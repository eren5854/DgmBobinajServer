using DgmBobinajServer.Context;
using DgmBobinajServer.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Repositories;

public sealed class GaleryRepository(ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Galery galery, CancellationToken cancellationToken)
    {
        await context.AddAsync(galery);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Resim kaydı başarılı");
    }

    public async Task<Result<List<Galery>>> GetAll(CancellationToken cancellationToken)
    {
        var galeries = await context.Galeries.ToListAsync(cancellationToken);
        return Result<List<Galery>>.Succeed(galeries);
    }

    public async Task<Result<List<Galery>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var galeries = await context.Galeries.Where(p => p.IsActive).ToListAsync(cancellationToken);
        return Result<List<Galery>>.Succeed(galeries);
    }

    public Galery? GetById(Guid Id)
    {
        return context.Galeries.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(Galery galery, CancellationToken cancellation)
    {
        context.Update(galery);
        await context.SaveChangesAsync(cancellation);
        return Result<string>.Succeed("Resim güncelleme başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Galery? galery = GetById(Id);
        if (galery is null)
        {
            return Result<string>.Succeed("Resim bulunamadı");
        }

        galery.IsDeleted = true;
        context.Update(galery);
        await context.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Resim silme başarılı");
    }
}
