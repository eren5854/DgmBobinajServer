namespace DgmBobinajServer.Models;

public sealed class Layout : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Subtitle {  get; set; } = string.Empty;
    public string Logo { get; set; } = string.Empty;
}
