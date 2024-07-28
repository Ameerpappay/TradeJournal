using Application.Dtos;
using Application.Dtos.UserAccount;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        private readonly IImageService _imageService;

        public UserAccountService(UserManager<User> userManager, IConfiguration configuration, SmtpClient smtpClient, IImageService imageService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _smtpClient = smtpClient;
            _imageService = imageService;
        }

        public async Task<JwtSecurityToken> Login(LoginRequestDto loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.UserName);

            if (user == null || !user.EmailConfirmed || !(await _userManager.CheckPasswordAsync(user, loginRequest.Password)))
            {
                throw new Exception("User not valid");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim("userIdentifier",user.Id),
                new Claim("emailId", user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

        public async Task<bool> Add(CreateAdminDto createUserRequest)
        {
            var isUserAdded = await AddUser(createUserRequest);

            if (!isUserAdded) return false;

            await AddRoleToUser(createUserRequest.Email, Domain.Enum.Role.Admin);

            return isUserAdded;
        }

        public async Task<bool> Add(CreateTraderDto createTraderRequest, string contentRoot)
        {
            var isUserAdded = await AddUser(createTraderRequest, contentRoot);
            if (!isUserAdded)
                return false;

            await AddRoleToUser(createTraderRequest.Email, Domain.Enum.Role.Trader);

            return isUserAdded;
        }

        private async Task<bool> AddUser(CreateUserDto createUserRequest)
        {
            var existingUser = await _userManager.FindByEmailAsync(createUserRequest.Email);

            if (existingUser != null)
            {
                return false;
            }

            User user = new User()
            {
                UserName = createUserRequest.Email,
                Email = createUserRequest.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, createUserRequest.Password);

            if (result.Succeeded)
            {
                var createdUser = await _userManager.FindByEmailAsync(createUserRequest.Email);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(createdUser);
                var confirmationLink = $"https://localhost:7228/api/user-accounts/verify-email?token={WebUtility.UrlEncode(token)}&userId={createdUser.Id}";

                await SendEmailAsync(createUserRequest.Email, "Confirm your email",
                    $"Please confirm your account by clicking this link: <a href='{confirmationLink}'>link</a>");
                return true;
            }
            else
            {
                return false;
            }
            // return result.Succeeded;
        }

        private async Task<bool> AddUser(CreateTraderDto createTraderDto, string contentRoot)
        {
            var existingUser = await _userManager.FindByEmailAsync(createTraderDto.Email);

            if (existingUser != null)
            {
                return false;
            }

            var imageUrl = "";
            if (createTraderDto.ImageFile != null)
            {
                imageUrl = await _imageService.UploadUserImage(createTraderDto.ImageFile, contentRoot);
            }

            User user = new User()
            {
                FirstName = createTraderDto.FirstName,
                LastName = createTraderDto.LastName,
                PhoneNumber = createTraderDto.Phone,
                UserName = createTraderDto.Email,
                Email = createTraderDto.Email,
                Photo = imageUrl,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, createTraderDto.Password);

            if (result.Succeeded)
            {
                var createdUser = await _userManager.FindByEmailAsync(createTraderDto.Email);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(createdUser);
                var confirmationLink = $"https://localhost:7228/api/user-accounts/verify-email?token={WebUtility.UrlEncode(token)}&userId={createdUser.Id}";

                await SendEmailAsync(createTraderDto.Email, "Confirm your email",
                    $"Please confirm your account by clicking this link: <a href='{confirmationLink}'>link</a>");
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task AddRoleToUser(string emailId, Domain.Enum.Role role)
        {
            var addedUser = await _userManager.FindByEmailAsync(emailId);

            await _userManager.AddToRoleAsync(addedUser, role.ToString());
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            var mailMessage = new MailMessage(from: _configuration["SmtpSettings:Username"].ToString(), to: email)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = body
            };

            await _smtpClient.SendMailAsync(mailMessage);
        }

        public async Task VerifyEmailAsync(string token, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("user not found");
            }

            var isTokenValid = await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, UserManager<User>.ConfirmEmailTokenPurpose, token);
            if (isTokenValid)
            {



                await _userManager.ConfirmEmailAsync(user, token);
            }
            else
            {
                throw new Exception($"Failed to verify email: {token}");
            }
        }

        public async Task<bool> ForgotPassword(string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser == null)
            {
                return false;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(existingUser);
            var confirmationLink = $"https://localhost:3000/api/user-accounts/Resetpassword?token={WebUtility.UrlEncode(token)}&userId={existingUser.Id}";

            await SendEmailAsync(email, "Reset your password",
                $"Please confirm your account by clicking this link: <a href='{confirmationLink}'>link</a>");
            return true;
        }

        public async Task<bool> ResetPassword(string token, string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("user not found");
            }
            await _userManager.ResetPasswordAsync(user, token, newPassword);
            return true;
        }
    }
}




