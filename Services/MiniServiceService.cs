using AutoMapper;
using DgmBobinajServer.DTOs.MiniService;
using DgmBobinajServer.Models;
using DgmBobinajServer.Repositories;
using ED.Result;
using GenericFileService.Files;

namespace DgmBobinajServer.Services;

public sealed class MiniServiceService(
    MiniServiceRepository miniServiceRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateMiniServiceDto request, CancellationToken cancellationToken)
    {
        string image = "";
        var response = request.Image;
        if (response is null)
        {
            image = "";
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Image!, "wwwroot/Images/");
        }

        MiniService miniService = mapper.Map<MiniService>(request);
        miniService.Image = image;
        miniService.CreatedBy = "Admin";
        miniService.CreatedDate = DateTime.Now;
        return await miniServiceRepository.Crete(miniService, cancellationToken);
    }

    public async Task<Result<List<MiniService>>> GetAll(CancellationToken cancellationToken)
    {
        return await miniServiceRepository.GetAll(cancellationToken);
    }

    public async Task<Result<List<MiniService>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        return await miniServiceRepository.GetAllByIsActive(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateMiniServiceDto request, CancellationToken cancellationToken)
    {
        MiniService? miniService = miniServiceRepository.GetById(request.Id);
        if (miniService is null)
        {
            return Result<string>.Failure("Mini Servis bulunamadı");
        }

        string image = "";
        var response = request.Image;
        if (response is null)
        {
            image = miniService.Image!;
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Image!, "wwwroot/Images/");
            FileService.FileDeleteToServer("wwwroot/Images/" + miniService.Image);
        }

        mapper.Map(request, miniService);
        miniService.Image = image;
        miniService.UpdatedDate = DateTime.Now;
        miniService.UpdatedBy = "Admin";

        return await miniServiceRepository.Update(miniService, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await miniServiceRepository.DeleteById(Id, cancellationToken);
    }
}
