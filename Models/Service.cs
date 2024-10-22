namespace DgmBobinajServer.Models;

public sealed class Service : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string? Image { get; set; }
}
