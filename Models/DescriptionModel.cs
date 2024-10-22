using DgmBobinajServer.Enums;

namespace DgmBobinajServer.Models;

public sealed class DescriptionModel : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string? Image { get; set; }
    public DescriptionModelEnum ModelEnum { get; set; }
}
