using DgmBobinajServer.Context;
using DgmBobinajServer.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Repositories;

public sealed class LayoutRepository(ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Layout layout, CancellationToken cancellationToken)
    {
        await context.AddAsync(layout, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Layout bilgileri kaydı başarılı");
    }

    public async Task<Result<List<Layout>>> GetAll(CancellationToken cancellationToken)
    {
        var layouts = await context.Layouts.ToListAsync(cancellationToken);
        return Result<List<Layout>>.Succeed(layouts);
    }

    public async Task<Result<List<Layout>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var layouts = await context.Layouts.Where(p => p.IsActive).ToListAsync(cancellationToken);
        return Result<List<Layout>>.Succeed(layouts);
    }

    public Layout? GetById(Guid Id)
    {
        return context.Layouts.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Layout? layout = GetById(Id);
        if (layout is null)
        {
            return Result<string>.Failure("Layout bilgileri bulunamadı");
        }

        layout.IsDeleted = true;
        context.Update(layout);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Layout bilgileri silme başarılı");
    }

    public async Task<Result<string>> Update(Layout layout, CancellationToken cancellationToken)
    {
        context.Update(layout);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Layout bilgileri güncelleme başarılı");

    }
}
