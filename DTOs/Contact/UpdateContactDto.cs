namespace DgmBobinajServer.DTOs.Contact;

public sealed record UpdateContactDto(
    Guid Id,
    bool IsRead);
