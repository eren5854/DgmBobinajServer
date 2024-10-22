namespace DgmBobinajServer.DTOs.Auth;

public sealed record ForgotPasswordDto(
    string Email,
    int? ForgotPasswordCode);