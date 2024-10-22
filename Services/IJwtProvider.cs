using DgmBobinajServer.DTOs.Auth;
using DgmBobinajServer.Models;

namespace DgmBobinajServer.Services;

public interface IJwtProvider
{
    Task<LoginResponseDto> CreateToken(AppUser user);
}
