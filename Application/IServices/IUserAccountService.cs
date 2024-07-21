using Application.Dtos;
using System.IdentityModel.Tokens.Jwt;

namespace Application.IServices
{
    public interface IUserAccountService
    {
        Task<bool> Add(CreateAdminDto createAdmin);

        Task<bool> Add(CreateTraderDto createTrader, string contentRoot);

        Task<JwtSecurityToken> Login(LoginRequestDto loginRequest);
        Task VerifyEmailAsync(string token, string userId);
        Task<bool> ForgotPassword(string email);
        Task<bool> ResetPassword(string token, string userId, string newPassword);
    }
}
