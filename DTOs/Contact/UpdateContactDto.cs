namespace DgmBobinajServer.DTOs.Contact;

public sealed record UpdateContactDto(string Name,
    Guid Id,
    bool IsRead);
