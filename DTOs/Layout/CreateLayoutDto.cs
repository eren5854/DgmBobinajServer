using DgmBobinajServer.DTOs.Link;
using DgmBobinajServer.DTOs.MiniService;

namespace DgmBobinajServer.DTOs.Layout;

public sealed record CreateLayoutDto(
    string Title,
    string Subtitle,
    IFormFile? Logo);
