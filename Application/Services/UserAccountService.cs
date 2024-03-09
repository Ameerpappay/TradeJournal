using Application.Dtos;
using Application.IServices;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly UserManager<User> _userManager;


        private readonly IConfiguration _configuration;
        public UserAccountService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<JwtSecurityToken> Login(LoginRequestDto loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.UserName);

            if (user == null || !(await _userManager.CheckPasswordAsync(user, loginRequest.Password))) return null;

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
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }


        public async Task<bool> CreateAdmin(CreateUserDto createUserRequest)
        {
            var isUserAdded = await AddUser(createUserRequest);

            if (!isUserAdded) return false;

            await AddRoleToUser(createUserRequest.Email, Role.Admin);

            return isUserAdded;
        }

        public async Task<bool> CreateTrader(CreateUserDto createUserRequest)
        {
            var isUserAdded = await AddUser(createUserRequest);

            if (!isUserAdded) return false;

            await AddRoleToUser(createUserRequest.Email, Role.Trader);

            return isUserAdded;
        }

        private async Task<bool> AddUser(CreateUserDto createUserRequest)
        {
            var existingUser = await _userManager.FindByEmailAsync(createUserRequest.Email);

            if (existingUser != null) return false;

            User user = new User()
            {
                UserName = createUserRequest.Email,
                Email = createUserRequest.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, createUserRequest.Password);

            return result.Succeeded;
        }

        private async Task AddRoleToUser(string emailId, Role role)
        {
            var addedUser = await _userManager.FindByEmailAsync(emailId);

            await _userManager.AddToRoleAsync(addedUser, role.ToString());
        }
    }
}
