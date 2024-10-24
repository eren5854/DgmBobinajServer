﻿using DgmBobinajServer.DTOs.Auth;
using DgmBobinajServer.Models;
using ED.GenericEmailService;
using ED.GenericEmailService.Models;
using ED.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DgmBobinajServer.Services;

public sealed class AuthService(
    UserManager<AppUser> userManager,
    IJwtProvider jwtProvider)
{
    public async Task<Result<LoginResponseDto>> Login(LoginDto request, CancellationToken cancellationToken)
    {
        string emailOrUserName = request.EmailOrUserName.ToUpper();
        AppUser? user = await userManager
            .Users.Where(p => !p.IsDeleted)
            .FirstOrDefaultAsync(p => p.Email == request.EmailOrUserName ||
            p.UserName == request.EmailOrUserName);
        if (user is null)
        {
            return Result<LoginResponseDto>.Failure("Kullanıcı bulunamadı");
        }

        bool result = await userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
        {
            return Result<LoginResponseDto>.Failure("Şifre Yanlış");
        }

        var loginResponse = await jwtProvider.CreateToken(user);
        return loginResponse;
    }

    public async Task<Result<string>> ChangePassword(ChangePasswordDto request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.Id.ToString());
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        IdentityResult result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Old password is wrong");
        }

        return Result<string>.Succeed("Password change is successful");
    }

    public async Task<Result<string>> ForgotPassword(ForgotPasswordDto request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        DateTime currentDateTime = DateTime.Now;
        if (user.ForgotPasswordCodeSendDate.HasValue && (currentDateTime - user.ForgotPasswordCodeSendDate.Value).TotalHours > 6)
        {
            return Result<string>.Failure("Kodun süresi geçmiş lütfen tekrar deneyiniz");
        }

        if (user.ForgotPasswordCode != request.ForgotPasswordCode)
        {
            return Result<string>.Failure("Kod Hatalı!!");
        }

        string token = await userManager.GeneratePasswordResetTokenAsync(user);
        return token;
    }

    public async Task<Result<string>> ChangePasswordUsingToken(ChangePasswordUsingTokenDto request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        IdentityResult result = await userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Error ");
        }

        return Result<string>.Succeed("New password is successful");
    }

    public async Task<Result<string>> SendForgotPasswordEmail(SendForgotPasswordEmailDto request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        Random random = new();
        user.ForgotPasswordCode = random.Next(100000, 999999);  // 6 haneli kod oluştur
        user.ForgotPasswordCodeSendDate = DateTime.Now;

        IdentityResult result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Record could not be created.");
        }

        string body = CreateBody(user.ForgotPasswordCode, user.Email);
        string subject = "Şifremi Unuttum";

        EmailConfigurations emailConfigurations = new(
           "*****",
           "***",
           465,
           true,
           true);

        EmailModel<Stream> emailModel = new(
            emailConfigurations,
            "*****",
            new List<string> { user.Email ?? "" },
            subject,
            body,
            null);

        await EmailService.SendEmailWithMailKitAsync(emailModel);

        return Result<string>.Succeed("Şifremi unuttum maili gönderildi");
    }

    private string CreateBody(int? code, string? email)
    {
        string body = $@"Şifrenizi değiştirmek için aşağıdaki linke tıklayın: 
<a href='https://link/forgot-password/{email}{code}' target='_blank'>https://link/forgot-password/{email}{code}
</a>";
        return body;
    }
}
