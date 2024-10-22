using AutoMapper;
using DgmBobinajServer.DTOs.Layout;
using DgmBobinajServer.Models;
using DgmBobinajServer.Repositories;
using ED.Result;
using GenericFileService.Files;

namespace DgmBobinajServer.Services;

public sealed class LayoutService(
    LayoutRepository layoutRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateLayoutDto request, CancellationToken cancellationToken)
    {
        string image = "";
        var response = request.Logo;
        if (response is null)
        {
            image = "";
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Logo!, "wwwroot/Images/");
        }

        Layout layout = mapper.Map<Layout>(request);
        layout.Logo = image;
        layout.CreatedBy = "Admin";
        layout.CreatedDate = DateTime.Now;

        return await layoutRepository.Create(layout, cancellationToken);
    }

    public async Task<Result<List<Layout>>> GetAll(CancellationToken cancellationToken)
    {
        return await layoutRepository.GetAll(cancellationToken);
    }

    public async Task<Result<List<Layout>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        return await layoutRepository.GetAllByIsActive(cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await layoutRepository.DeleteById(Id, cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateLayoutDto request, CancellationToken cancellationToken)
    {
        Layout? layout = layoutRepository.GetById(request.Id);
        if (layout is null)
        {
            return Result<string>.Failure("Layout kaydı bulunamadı");
        }

        string image = "";
        var response = request.Logo;
        if (response is null)
        {
            image = layout.Logo!;
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Logo!, "wwwroot/Images/");
            FileService.FileDeleteToServer("wwwroot/Images/" + layout.Logo);
        }

        mapper.Map(request, layout);
        layout.Logo = image;
        layout.UpdatedDate = DateTime.Now;
        layout.UpdatedBy = "Admin";

        return await layoutRepository.Update(layout, cancellationToken);
    }
}
