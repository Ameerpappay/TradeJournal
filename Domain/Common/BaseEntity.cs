using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            DateCreated = DateTime.UtcNow;
            Identifier = Guid.NewGuid();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid Identifier { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateUpdated { get; set; }

        public DateTimeOffset? DateDeleted { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        [Required]
        public User CreatedBy { get; set; }

        public string? UpdatedByUserId { get; set; }

        public User UpdatedBy { get; set;}
    }
}
