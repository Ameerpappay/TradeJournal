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
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public DateTime? DateDeleted { get; set; }

        public bool IsDeleted { get; set; }

        protected BaseEntity()
        {
            DateCreated = DateTime.UtcNow;
        }
    }
}
