using Application.Dtos;
using Application.IServices;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/user-accounts")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost("trader")]
        public async Task<IActionResult> Add([FromBody] CreateTraderDto createUserRequest)
        {
            var response = await _userAccountService.Add(createUserRequest);

            if (response) return Ok("User Created Successfully");

            return BadRequest("Either user creation failed or user already exists");
        }


        [HttpPost("admin")]
        public async Task<IActionResult> Add([FromBody] CreateAdminDto createUserRequest)
        {
            var response = await _userAccountService.Add(createUserRequest);

            if (response) return Ok("User Created Successfully");

            return BadRequest("Either user creation failed or user already exists");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var response = await _userAccountService.Login(loginRequest);

            if (response == null) return BadRequest("Invalid User");

            return Ok(new{token = new JwtSecurityTokenHandler().WriteToken(response)});
        }
    }
}
