using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Strategy : BaseEntity
    {
        [Required(ErrorMessage = "Name is required" ,AllowEmptyStrings =false)]
        [MinLength(1, ErrorMessage = "Name must not be empty")]

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Trade> Trades { get; set;}
    }
}
