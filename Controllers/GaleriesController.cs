using DgmBobinajServer.DTOs.Galery;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgmBobinajServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class GaleriesController(
    GaleryService galeryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateGaleryDto request, CancellationToken cancellationToken)
    {
        var response = await galeryService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellation)
    {
        var response = await galeryService.GetAll(cancellation);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByIsActive(CancellationToken cancellation)
    {
        var response = await galeryService.GetAllByIsActive(cancellation);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm]UpdateGaleryDto request, CancellationToken cancellationToken)
    {
        var response = await galeryService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);

    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id,CancellationToken cancellationToken)
    {
        var response = await galeryService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
