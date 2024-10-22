namespace DgmBobinajServer.Models;

public sealed class Information : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Fax { get; set; }
    public string Address {  get; set; } = string.Empty;
    public string Email {  get; set; } = string.Empty;
}
