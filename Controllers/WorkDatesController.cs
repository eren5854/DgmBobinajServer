using DgmBobinajServer.DTOs.WorkDate;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgmBobinajServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class WorkDatesController(
    WorkDateService workDateService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateWorkDateDto request, CancellationToken cancellationToken)
    {
        var response = await workDateService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await workDateService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateWorkDateDto request, CancellationToken cancellationToken)
    {
        var response = await workDateService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await workDateService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
