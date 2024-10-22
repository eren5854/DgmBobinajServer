using DgmBobinajServer.Context;
using DgmBobinajServer.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Repositories;

public sealed class CommentRepository(ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Comment comment, CancellationToken cancellationToken)
    {
        await context.AddAsync(comment);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Yorum oluşturma başarılı");
    }

    public async Task<Result<List<Comment>>> GetAll(CancellationToken cancellation)
    {
        var comments = await context.Comments.ToListAsync(cancellation);
        return Result<List<Comment>>.Succeed(comments);
    }

    public async Task<Result<List<Comment>>> GetAllByIsActive(CancellationToken cancellation)
    {
        var comments = await context.Comments.Where(p => p.IsActive).ToListAsync(cancellation);
        return Result<List<Comment>>.Succeed(comments);
    }

    public Comment? GetById(Guid Id)
    {
        return context.Comments.Where(p=> p.Id == Id).FirstOrDefault();
    }

    //public async Task<Result<Comment>> GetById(Guid Id)
    //{
    //    Comment? comment = await context.Comments.Where(p => p.Id == Id).FirstOrDefaultAsync();
    //    if (comment is null)
    //    {
    //        return Result<Comment>.Failure("Yorum bulunamadı");
    //    }

    //    return Result<Comment>.Succeed(comment);
    //}

    public async Task<Result<string>> Update(Comment comment, CancellationToken cancellationToken)
    {
        context.Update(comment);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Yorum güncelleme başarılı");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellation)
    {
        Comment? comment = GetById(Id);
        if (comment is null)
        {
            return Result<string>.Failure("Yorum bulunamadı");
        }

        comment.IsDeleted = true;
        context.Update(comment);
        await context.SaveChangesAsync(cancellation);
        return Result<string>.Succeed("Yorum silme başarılı");
    }
}
