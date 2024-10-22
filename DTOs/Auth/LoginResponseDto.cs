namespace DgmBobinajServer.DTOs.Auth;

public sealed record LoginResponseDto(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires);
