using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Strategy : BaseEntity
    {
        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "Name must not be empty")]

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Trade> Trades { get; set; }
    }
}
