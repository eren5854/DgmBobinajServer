namespace DgmBobinajServer.DTOs.MiniService;

public sealed record CreateMiniServiceDto(
    string Title,
    string Subtitle,
    IFormFile? Image);