namespace DgmBobinajServer.DTOs.Auth;

public sealed record ChangePasswordUsingTokenDto(
    string Email,
    string NewPassword,
    string Token);
