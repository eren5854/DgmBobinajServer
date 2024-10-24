using DgmBobinajServer.DTOs.DescriptionModelDto;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgmBobinajServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class DescriptionModelsController(
    DescriptionModelService descriptionModelService) : ControllerBase
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateDescriptionModelDto request, CancellationToken cancellationToken)
    {
        var response = await descriptionModelService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellation)
    {
        var response = await descriptionModelService.GetAll(cancellation);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByIsActive(CancellationToken cancellation)
    {
        var response = await descriptionModelService.GetAllByIsActive(cancellation);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Update([FromForm]UpdateDescriptionModelDto request, CancellationToken cancellationToken)
    {
        var response = await descriptionModelService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> UpdateIsActive(Guid Id, CancellationToken cancellationToken)
    {
        var response = await descriptionModelService.UpdateIsActive(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await descriptionModelService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
