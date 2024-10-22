using AutoMapper;
using DgmBobinajServer.DTOs.WorkDate;
using DgmBobinajServer.Models;
using DgmBobinajServer.Repositories;
using ED.Result;

namespace DgmBobinajServer.Services;

public sealed class WorkDateService(
    WorkDateRepository workDateRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateWorkDateDto request, CancellationToken cancellationToken)
    {
        WorkDate workDate = mapper.Map<WorkDate>(request);
        workDate.CreatedBy = "Admin";
        workDate.CreatedDate = DateTime.Now;
        return await workDateRepository.Create(workDate, cancellationToken);
    }

    public async Task<Result<List<WorkDate>>> GetAll(CancellationToken cancellationToken)
    {
        return await workDateRepository.GetAll(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateWorkDateDto request, CancellationToken cancellationToken)
    {
        WorkDate? workDate = workDateRepository.GetById(request.Id);
        if (workDate is null)
        {
            return Result<string>.Failure("Gün bulunamadı");
        }

        mapper.Map(request, workDate);
        workDate.UpdatedDate = DateTime.Now;
        workDate.UpdatedBy = "Admin";
        return await workDateRepository.Update(workDate, cancellationToken);        
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await workDateRepository.DeleteById(Id, cancellationToken);
    }
}
