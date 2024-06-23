using Application.Dtos.UserAccount;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CreateTraderDto:CreateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

       //  public string PhotoUrl { get; set; }
       public IFormFile ImageFile { get; set; }


    }
}
