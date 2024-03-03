using System;
using System.Collections.Generic;
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
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateUpdated { get; set; }

        public DateTimeOffset? DateDeleted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
