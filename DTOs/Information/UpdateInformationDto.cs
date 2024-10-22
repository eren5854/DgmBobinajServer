namespace DgmBobinajServer.DTOs.Information;

public sealed record UpdateInformationDto(
    Guid Id,
    string Name,
    string Phone,
    string? Fax,
    string Address,
    string Email,
    bool IsActive);
