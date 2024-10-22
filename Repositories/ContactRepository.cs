using DgmBobinajServer.Context;
using DgmBobinajServer.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Repositories;

public sealed class ContactRepository(ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Contact contact, CancellationToken cancellationToken)
    {
        await context.AddAsync(contact, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Mwsaj gönderildi");
    }

    public async Task<Result<List<Contact>>> GetAll(CancellationToken cancellationToken)
    {
        var contacts = await context.Contacts.OrderByDescending(o => o.CreatedDate).ToListAsync(cancellationToken);
        return Result<List<Contact>>.Succeed(contacts);
    }

    public Contact? GetById(Guid id)
    {
        return context.Contacts.Where(p => p.Id == id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(Contact contact, CancellationToken cancellationToken)
    {
        context.Update(contact);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Mesaj okundu");

    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Contact? contact = GetById(Id);
        if (contact is null)
        {
            return Result<string>.Succeed("Mesaj bulunamadı");
        }
        
        contact.IsDeleted = true;
        context.Update(contact);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Mesaj silme başarılı");
    }
}
