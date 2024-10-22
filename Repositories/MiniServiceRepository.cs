using DgmBobinajServer.Context;
using DgmBobinajServer.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Repositories;

public sealed class MiniServiceRepository(
    ApplicationDbContext context)
{
    public async Task<Result<string>> Crete(MiniService miniService, CancellationToken cancellationToken)
    {
        await context.AddAsync(miniService, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Mini servis kaydı başarılı");
    }

    public async Task<Result<List<MiniService>>> GetAll(CancellationToken cancellationToken)
    {
        var miniServices = await context.MiniServices.ToListAsync(cancellationToken);
        return Result<List<MiniService>>.Succeed(miniServices);
    }

    public async Task<Result<List<MiniService>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var miniServices = await context.MiniServices.Where(p => p.IsActive).ToListAsync(cancellationToken);
        return Result<List<MiniService>>.Succeed(miniServices);
    }

    public MiniService? GetById(Guid Id)
    {
        return context.MiniServices.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(MiniService miniService, CancellationToken cancellationToken)
    {
        context.Update(miniService);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Mini servis güncelleme başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellation)
    {
        MiniService? miniService = GetById(Id);
        if (miniService is null)
        {
            return Result<string>.Failure("Mini servis bulunamadı");
        }

        miniService.IsDeleted = true;
        context.Update(miniService);
        await context.SaveChangesAsync(cancellation);

        return Result<string>.Succeed("Mini servis silme başarılı");
    }
}
