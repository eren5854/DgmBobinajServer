using DgmBobinajServer.DTOs.Information;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgmBobinajServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class InformationsController(InformationService informationService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateInformationDto request, CancellationToken cancellationToken)
    {
        var response = await informationService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await informationService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var response = await informationService.GetAllByIsActive(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateInformationDto request, CancellationToken cancellationToken)
    {
        var response = await informationService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await informationService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
