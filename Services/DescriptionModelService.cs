using AutoMapper;
using DgmBobinajServer.DTOs.DescriptionModelDto;
using DgmBobinajServer.Models;
using DgmBobinajServer.Repositories;
using ED.Result;
using GenericFileService.Files;

namespace DgmBobinajServer.Services;

public sealed class DescriptionModelService(
    DescriptionModelRepository descriptionModelRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateDescriptionModelDto request, CancellationToken cancellationToken)
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

        DescriptionModel descriptionModel = mapper.Map<DescriptionModel>(request);
        descriptionModel.Image = image;
        descriptionModel.CreatedDate = DateTime.Now;
        descriptionModel.CreatedBy = "Admin";

        return await descriptionModelRepository.Create(descriptionModel, cancellationToken);
    }

    public async Task<Result<List<DescriptionModel>>> GetAll(CancellationToken cancellationToken)
    {
        return await descriptionModelRepository.GetAll(cancellationToken);
    }

    public async Task<Result<List<DescriptionModel>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        return await descriptionModelRepository.GetAllByIsActive(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateDescriptionModelDto request, CancellationToken cancellationToken)
    {
        DescriptionModel? descriptionModel = descriptionModelRepository.GetById(request.Id);
        if (descriptionModel is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        string image = "";
        var response = request.Image;
        if (response is null)
        {
            image = descriptionModel.Image!;
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Image!, "wwwroot/Images/");
            FileService.FileDeleteToServer("wwwroot/Images/" + descriptionModel.Image);
        }

        mapper.Map(request, descriptionModel);
        descriptionModel.Image = image;
        descriptionModel.UpdatedDate = DateTime.Now;
        descriptionModel.UpdatedBy = "Admin";

        return await descriptionModelRepository.Update(descriptionModel, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await descriptionModelRepository.DeleteById(Id, cancellationToken);
    }
}
