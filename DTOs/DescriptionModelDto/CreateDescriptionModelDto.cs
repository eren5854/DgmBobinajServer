using DgmBobinajServer.Enums;

namespace DgmBobinajServer.DTOs.DescriptionModelDto;

public sealed record CreateDescriptionModelDto(
    string Title,
    string Text,
    IFormFile? Image,
    DescriptionModelEnum ModelEnum);
