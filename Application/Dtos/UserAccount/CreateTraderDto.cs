using Application.Dtos.UserAccount;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
    public class CreateTraderDto : CreateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        //  public string PhotoUrl { get; set; }
        public IFormFile ImageFile { get; set; }


    }
}
