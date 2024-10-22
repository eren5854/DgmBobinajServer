namespace DgmBobinajServer.DTOs.Auth;

public sealed record ChangePasswordDto(
    Guid Id,
    string CurrentPassword,
    string NewPassword);
