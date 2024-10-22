using DgmBobinajServer.Enums;

namespace DgmBobinajServer.DTOs.Galery;

public sealed record CreateGaleryDto(
    IFormFile? Image,
    GaleryEnum GaleryEnum);
