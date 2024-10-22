using DgmBobinajServer.Enums;

namespace DgmBobinajServer.DTOs.Link;

public sealed record CreateLinkDto(
    string Url,
    LinkTypeEnum LinkType);
