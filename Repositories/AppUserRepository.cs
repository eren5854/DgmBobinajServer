using DgmBobinajServer.Context;
using DgmBobinajServer.Models;
using ED.GenericRepository;
using ED.Result;

namespace DgmBobinajServer.Repositories;

public sealed class AppUserRepository(ApplicationDbContext context)
{
    public async Task<Result<string>> Update(AppUser appUser, CancellationToken cancellationToken)
    {
        context.Update(appUser);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Kullanıcı güncelleme işlemi başarılı");
    }
}
