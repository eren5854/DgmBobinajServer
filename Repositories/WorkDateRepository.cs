using DgmBobinajServer.Context;
using DgmBobinajServer.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Repositories;

public sealed class WorkDateRepository(ApplicationDbContext context)
{
    public async Task<Result<string>> Create(WorkDate workDate, CancellationToken cancellationToken)
    {
        await context.AddAsync(workDate, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Gün kaydı başarılı");
    }

    public async Task<Result<List<WorkDate>>> GetAll(CancellationToken cancellation)
    {
        var workDates = await context.WorkDates.OrderBy(o => o.CreatedDate).ToListAsync(cancellation);
        return Result<List<WorkDate>>.Succeed(workDates);
    }

    public WorkDate? GetById(Guid Id)
    {
        return context.WorkDates.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(WorkDate workDate, CancellationToken cancellationToken)
    {
        context.Update(workDate);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Gün güncelleme başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        WorkDate? workDate = GetById(Id);
        if (workDate is null)
        {
            return Result<string>.Failure("Gün bulunamadı");
        }

        workDate.IsDeleted = true;
        context.Update(workDate);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Gün silme başarılı");
    }
}
