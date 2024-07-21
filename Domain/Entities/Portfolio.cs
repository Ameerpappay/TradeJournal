using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Portfolio : BaseEntity
    {
        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "Name must not be empty")]

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Holding>? Holdings { get; set; }

        public bool IsSelected { get; set; }

    }
}
