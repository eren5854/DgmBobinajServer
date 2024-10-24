using AutoMapper;
using DgmBobinajServer.DTOs.Link;
using DgmBobinajServer.Models;
using DgmBobinajServer.Repositories;
using ED.Result;

namespace DgmBobinajServer.Services;

public sealed class LinkService(
    LinkRepository linkRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateLinkDto request, CancellationToken cancellationToken)
    {
        Link link = mapper.Map<Link>(request);
        link.CreatedDate = DateTime.Now;
        link.CreatedBy = "Admin";

        return await linkRepository.Create(link, cancellationToken);
    }

    public async Task<Result<List<Link>>> GetAll(CancellationToken cancellationToken)
    {
        return await linkRepository.GetAll(cancellationToken);
    }

    public async Task<Result<List<Link>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        return await linkRepository.GetAllByIsActive(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateLinkDto request, CancellationToken cancellationToken)
    {
        Link? link = linkRepository.GetById(request.Id);
        if (link is null)
        {
            return Result<string>.Failure("Link kaydı bulunamadı");
        }

        mapper.Map(request, link);
        link.UpdatedDate = DateTime.Now;
        link.UpdatedBy = "Admin";

        return await linkRepository.Update(link, cancellationToken);
    }

    public async Task<Result<string>> UpdateIsActive(Guid Id, CancellationToken cancellation)
    {
        Link? link = linkRepository.GetById(Id);
        if (link is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        link.IsActive = !link.IsActive;
        link.UpdatedDate = DateTime.Now;
        link.UpdatedBy = "Admin";
        return await linkRepository.Update(link, cancellation);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await linkRepository.DeleteByıd(Id, cancellationToken);
    }
}
