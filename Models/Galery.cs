using DgmBobinajServer.Enums;

namespace DgmBobinajServer.Models;

public sealed class Galery : Entity
{
    public string? Image { get; set; }
    public GaleryEnum GaleryEnum { get; set; }
}
