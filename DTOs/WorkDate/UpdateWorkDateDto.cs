namespace DgmBobinajServer.DTOs.WorkDate;

public sealed record UpdateWorkDateDto(
    Guid Id,
    string Day,
    string Time);
