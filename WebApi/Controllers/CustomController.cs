using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CustomController :ControllerBase
    {  
        public string GetUser()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            return userId;
        }
    }
}
