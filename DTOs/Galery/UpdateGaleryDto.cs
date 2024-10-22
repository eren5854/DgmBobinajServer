using DgmBobinajServer.Enums;

namespace DgmBobinajServer.DTOs.Galery;

public sealed record UpdateGaleryDto(
    Guid Id,
    IFormFile? Image,
    GaleryEnum GaleryEnum,
    bool IsActive);
