namespace DgmBobinajServer.DTOs.MiniService;

public sealed record UpdateMiniServiceDto(
    Guid Id,
    string Title,
    string Subtitle,
    IFormFile? Image,
    bool IsActive);
