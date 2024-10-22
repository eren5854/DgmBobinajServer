using Microsoft.AspNetCore.Identity;

namespace DgmBobinajServer.Models;

public sealed class AppUser : IdentityUser<Guid>
{
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }

    public int? ForgotPasswordCode { get; set; }
    public DateTime? ForgotPasswordCodeSendDate { get; set; }

    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
