using Domain.Entities;
using System.Security.Claims;

namespace WebApi.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            //var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            var userId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            return userId;
        }
    }
}
