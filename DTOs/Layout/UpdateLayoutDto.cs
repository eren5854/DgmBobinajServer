namespace DgmBobinajServer.DTOs.Layout;

public sealed record UpdateLayoutDto(
    Guid Id,
    string Title,
    string Subtitle,
    IFormFile? Logo,
    bool? IsActive);