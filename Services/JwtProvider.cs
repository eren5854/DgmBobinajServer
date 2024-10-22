using DgmBobinajServer.DTOs.Auth;
using DgmBobinajServer.Models;
using DgmBobinajServer.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DgmBobinajServer.Services;

public class JwtProvider(
    UserManager<AppUser> userManager,
    IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    public async Task<LoginResponseDto> CreateToken(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Email ?? ""),
            //new Claim("UserName", user.UserName ?? ""),
            //new Claim("UserRole", user.UserRole.ToString())
        };

        DateTime expires = DateTime.Now.AddHours(24);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));

        JwtSecurityToken jwtSecurityToken = new(
            issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(jwtSecurityToken);

        string refreshToken = Guid.NewGuid().ToString();
        DateTime refreshToneExpires = expires;

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = refreshToneExpires;

        await userManager.UpdateAsync(user);

        return new(token, refreshToken, refreshToneExpires);
    }
}
