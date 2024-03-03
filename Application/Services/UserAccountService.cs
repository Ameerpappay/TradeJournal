using Application.Dtos;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public UserAccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<bool> CreateRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(
                new IdentityRole 
                {
                    Name = roleName,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
            });

            return result.Succeeded;
        }

        public async Task<bool> CreateUser(CreateUserDto createUserRequest)
        {
            var userExists = await _userManager.FindByEmailAsync(createUserRequest.Email);

            if (userExists != null) return false;

            User user = new User()
            {
                UserName = createUserRequest.Email,
                Email = createUserRequest.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, createUserRequest.Password);
            var iscorrect = await _userManager.CheckPasswordAsync(user, createUserRequest.Password);
            return result.Succeeded;
        }

        public async Task<JwtSecurityToken> Login(LoginRequestDto loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.UserName);

            if (user == null || !(await _userManager.CheckPasswordAsync(user, loginRequest.Password))) return null;

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
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
    }
}
