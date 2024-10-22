using DgmBobinajServer.Enums;

namespace DgmBobinajServer.DTOs.DescriptionModelDto;

public sealed record UpdateDescriptionModelDto(
    Guid Id,
    string Title,
    string Text,
    IFormFile? Image,
    DescriptionModelEnum ModelEnum,
    bool IsActive);
