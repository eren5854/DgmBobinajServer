namespace DgmBobinajServer.Models;

public sealed class Process : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string? Image { get; set; }
}
