using DgmBobinajServer.Context;
using DgmBobinajServer.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Repositories;

public sealed class InformationRepository(ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Information information, CancellationToken cancellationToken)
    {
        await context.AddAsync(information, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Site bilgisi kaydı başarılı");
    }

    public async Task<Result<List<Information>>> GetAll(CancellationToken cancellationToken)
    {
        var informations = await context.Informations.ToListAsync(cancellationToken);
        return Result<List<Information>>.Succeed(informations);
    }

    public async Task<Result<List<Information>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var informations = await context.Informations.Where(p => p.IsActive).ToListAsync(cancellationToken);
        return Result<List<Information>>.Succeed(informations);
    }

    public Information? GetById(Guid Id)
    {
        return context.Informations.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(Information information, CancellationToken cancellationToken)
    {
        context.Update(information);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("İletişim bilgisi güncelleme başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Information? information = GetById(Id);
        if (information is null)
        {
            return Result<string>.Failure("İletişim bilgisi bulunamadı");
        }

        information.IsDeleted = true;
        context.Update(information);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("iletişim bilgisi silme başarılı");
    }
}
