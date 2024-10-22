using DgmBobinajServer.Enums;

namespace DgmBobinajServer.DTOs.Link;

public sealed record UpdateLinkDto(
    Guid Id,
    string Url,
    LinkTypeEnum LinkType,
    bool IsActive);
