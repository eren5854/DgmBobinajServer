namespace DgmBobinajServer.DTOs.Auth;

public sealed record LoginDto(
    string EmailOrUserName,
    string Password);
