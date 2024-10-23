using DgmBobinajServer.Context;
using DgmBobinajServer.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Repositories;

public sealed class DescriptionModelRepository(ApplicationDbContext context)
{
    public async Task<Result<string>> Create(DescriptionModel descriptionModel, CancellationToken cancellationToken)
    {
        await context.AddAsync(descriptionModel, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Kayıt başarılı");
    }

    public async Task<Result<List<DescriptionModel>>> GetAll(CancellationToken cancellationToken)
    {
        var descriptionModels = await context.DescriptionModels.OrderBy(o => o.CreatedDate).ToListAsync(cancellationToken);
        return Result<List<DescriptionModel>>.Succeed(descriptionModels);
    }

    public async Task<Result<List<DescriptionModel>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var descriptionModels = await context.DescriptionModels.OrderBy(o => o.CreatedDate).Where(p => p.IsActive).ToListAsync(cancellationToken);
        return Result<List<DescriptionModel>>.Succeed(descriptionModels);
    }

    public DescriptionModel? GetById(Guid Id)
    {
        return context.DescriptionModels.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(DescriptionModel descriptionModel, CancellationToken cancellationToken)
    {
        context.Update(descriptionModel);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Güncelleme başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        DescriptionModel? descriptionModel = GetById(Id);
        if (descriptionModel is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        descriptionModel.IsDeleted = true;
        context.Update(descriptionModel);
        await context.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Silme başarılı");
    }
}
