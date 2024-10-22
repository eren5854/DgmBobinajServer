using DgmBobinajServer.DTOs.Comment;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgmBobinajServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CommentsController(CommentService commentService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateCommentDto request, CancellationToken cancellationToken)
    {
        var response = await commentService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await commentService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByIsActive(CancellationToken cancellationToken)
    {
        var response = await commentService.GetAllByIsActive(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCommentDto request, CancellationToken cancellationToken)
    {
        var response = await commentService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await commentService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
