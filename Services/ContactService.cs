using AutoMapper;
using DgmBobinajServer.DTOs.Contact;
using DgmBobinajServer.Models;
using DgmBobinajServer.Repositories;
using ED.Result;

namespace DgmBobinajServer.Services;

public sealed class ContactService(
    ContactRepository contactRepository, 
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateContacDto request, CancellationToken cancellationToken)
    {
        Contact contact = mapper.Map<Contact>(contactRepository);
        contact.CreatedBy = request.Name;
        contact.CreatedDate = DateTime.Now;
        return await contactRepository.Create(contact, cancellationToken);
    }

    public async Task<Result<List<Contact>>> GetAll(CancellationToken cancellationToken)
    {
        return await contactRepository.GetAll(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateContactDto request, CancellationToken cancellationToken)
    {
        Contact? contact = contactRepository.GetById(request.Id);
        if (contact is null)
        {
            return Result<string>.Failure("Mesaj bulunamadı");
        }

        mapper.Map(request, contact);
        contact.UpdatedDate = DateTime.Now;
        contact.UpdatedBy = "Admin";

        return await contactRepository.Update(contact, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await contactRepository.DeleteById(Id, cancellationToken);
    }
}
