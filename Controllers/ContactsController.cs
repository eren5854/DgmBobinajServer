using DgmBobinajServer.DTOs.Contact;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgmBobinajServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ContactsController(ContactService contactService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateContacDto request, CancellationToken cancellationToken)
    {
        var response = await contactService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await contactService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateContactDto request, CancellationToken cancellationToken)
    {
        var response = await contactService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await contactService.DeleteById(Id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
