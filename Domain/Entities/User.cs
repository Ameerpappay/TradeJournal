//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User 
    {
        [Required]
        public required string Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
    }
}