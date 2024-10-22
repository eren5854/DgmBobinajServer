namespace DgmBobinajServer.DTOs.Contact;

public sealed record CreateContacDto(
    string Name,
    string Phone,
    string Email,
    string Subject,
    string Content);
