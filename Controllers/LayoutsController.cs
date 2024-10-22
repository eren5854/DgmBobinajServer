using DgmBobinajServer.DTOs.Layout;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgmBobinajServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class LayoutsController(
    LayoutService layoutService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateLayoutDto request, CancellationToken cancellationToken)
    {
        var response = await layoutService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await layoutService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var response = await layoutService.GetAllByIsActive(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm]UpdateLayoutDto request, CancellationToken cancellationToken)
    {
        var response = await layoutService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await layoutService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
