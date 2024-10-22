using DgmBobinajServer.Models;
using Microsoft.AspNetCore.Identity;

namespace DgmBobinajServer.Middlewares;

public static class ExtensionMiddleware
{
    public static void CreateAdmin(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any(p => p.Email == "info@marqexmarine.com"))
            {
                AppUser user = new()
                {
                    UserName = "soner",
                    Email = "info@dgmbobinaj.com",
                    IsDeleted = false,
                    EmailConfirmed = true,
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now,
                };

                userManager.CreateAsync(user, "Password123*").Wait();
            }
        }
    }
}
