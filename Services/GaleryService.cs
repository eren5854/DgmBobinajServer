using AutoMapper;
using DgmBobinajServer.DTOs.Galery;
using DgmBobinajServer.Models;
using DgmBobinajServer.Repositories;
using ED.Result;
using GenericFileService.Files;

namespace DgmBobinajServer.Services;

public sealed class GaleryService(
    GaleryRepository galeryRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateGaleryDto request, CancellationToken cancellationToken)
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

        Galery galery = mapper.Map<Galery>(request);
        galery.Image = image;
        galery.CreatedDate = DateTime.Now;
        galery.CreatedBy = "Admin";

        return await galeryRepository.Create(galery, cancellationToken);
    }

    public async Task<Result<List<Galery>>> GetAll(CancellationToken cancellationToken)
    {
        return await galeryRepository.GetAll(cancellationToken);
    }

    public async Task<Result<List<Galery>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        return await galeryRepository.GetAllByIsActive(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateGaleryDto request, CancellationToken cancellationToken)
    {
        Galery? galery = galeryRepository.GetById(request.Id);
        if (galery is null)
        {
            return Result<string>.Failure("Resim bulunamadı");
        }

        string image = "";
        var response = request.Image;
        if (response is null)
        {
            image = galery.Image!;
        }
        if (response is not null)
        {
            image = FileService.FileSaveToServer(request.Image!, "wwwroot/Images/");
            FileService.FileDeleteToServer("wwwroot/Images/" + galery.Image);
        }

        mapper.Map(request, galery);
        galery.Image = image;
        galery.UpdatedDate = DateTime.Now;
        galery.UpdatedBy = "Admin";

        return await galeryRepository.Update(galery, cancellationToken);
    }

    public async Task<Result<string>> UpdateIsActive(Guid Id, CancellationToken cancellation)
    {
        Galery? descriptionModel = galeryRepository.GetById(Id);
        if (descriptionModel is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        descriptionModel.IsActive = !descriptionModel.IsActive;
        descriptionModel.UpdatedDate = DateTime.Now;
        descriptionModel.UpdatedBy = "Admin";
        return await galeryRepository.Update(descriptionModel, cancellation);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await galeryRepository.DeleteById(Id, cancellationToken);
    }
}
