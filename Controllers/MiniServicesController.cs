using Azure;
using DgmBobinajServer.DTOs.MiniService;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgmBobinajServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class MiniServicesController(
    MiniServiceService miniServiceService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateMiniServiceDto request, CancellationToken cancellationToken)
    {
        var response = await miniServiceService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await miniServiceService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var response = await miniServiceService.GetAllByIsActive(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm]UpdateMiniServiceDto request, CancellationToken cancellationToken)
    {
        var response = await miniServiceService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await miniServiceService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
