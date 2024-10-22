using DgmBobinajServer.DTOs.Auth;
using DgmBobinajServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DgmBobinajServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
    {
        var response = await authService.Login(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto request, CancellationToken cancellationToken)
    {
        var response = await authService.ChangePassword(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDto request, CancellationToken cancellationToken)
    {
        var response = await authService.ForgotPassword(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> ChangePasswordUsingToken(ChangePasswordUsingTokenDto request, CancellationToken cancellationToken)
    {
        var response = await authService.ChangePasswordUsingToken(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> SendForgotPasswordEmail(SendForgotPasswordEmailDto request, CancellationToken cancellationToken)
    {
        var response = await authService.SendForgotPasswordEmail(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
