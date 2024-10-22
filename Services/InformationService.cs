using AutoMapper;
using DgmBobinajServer.DTOs.Information;
using DgmBobinajServer.Models;
using DgmBobinajServer.Repositories;
using ED.Result;

namespace DgmBobinajServer.Services;

public sealed class InformationService(
    InformationRepository informationRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateInformationDto request, CancellationToken cancellationToken)
    {
        Information information = mapper.Map<Information>(request);
        information.CreatedDate = DateTime.Now;
        information.CreatedBy = "Admin";
        return await informationRepository.Create(information, cancellationToken);
    }

    public async Task<Result<List<Information>>> GetAll(CancellationToken cancellationToken)
    {
        return await informationRepository.GetAll(cancellationToken);
    }

    public async Task<Result<List<Information>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        return await informationRepository.GetAllByIsActive(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateInformationDto request, CancellationToken cancellationToken)
    {
        Information? information = informationRepository.GetById(request.Id);
        if (information is null)
        {
            return Result<string>.Failure("Site bilgisi bulunamadı");
        }

        mapper.Map(request, information);
        information.UpdatedDate = DateTime.Now;
        information.UpdatedBy = "Admin";
        return await informationRepository.Update(information, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await informationRepository.DeleteById(Id, cancellationToken);
    }
}
