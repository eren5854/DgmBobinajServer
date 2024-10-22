using DgmBobinajServer.Enums;

namespace DgmBobinajServer.Models;

public sealed class Link : Entity
{
    public string Url { get; set; } = string.Empty;
    public LinkTypeEnum LinkType { get; set; }
}
