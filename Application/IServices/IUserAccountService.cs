using Application.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserAccountService
    {
        Task<bool> CreateAdmin(CreateUserDto createUserDto);

        Task<bool> CreateTrader (CreateUserDto createUserRequest);

        Task<JwtSecurityToken> Login (LoginRequestDto loginRequest);
    }
}
