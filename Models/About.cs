namespace DgmBobinajServer.Models;

public sealed class About : Entity
{
    public string Text { get; set; } = string.Empty;
    public string? Image {  get; set; }
}
