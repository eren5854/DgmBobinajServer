﻿using DgmBobinajServer.DTOs.Link;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgmBobinajServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class LinksController(
    LinkService linkService) : ControllerBase
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateLinkDto request, CancellationToken cancellationToken)
    {
        var response = await linkService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await linkService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var response = await linkService.GetAllByIsActive(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Update(UpdateLinkDto request, CancellationToken cancellationToken)
    {
        var response = await linkService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> UpdateIsActive(Guid Id, CancellationToken cancellationToken)
    {
        var response = await linkService.UpdateIsActive(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await linkService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
