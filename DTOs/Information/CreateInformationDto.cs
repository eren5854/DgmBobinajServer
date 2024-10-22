namespace DgmBobinajServer.DTOs.Information;

public sealed record CreateInformationDto(
    string Name,
    string Phone,
    string Fax,
    string Address,
    string Email);
