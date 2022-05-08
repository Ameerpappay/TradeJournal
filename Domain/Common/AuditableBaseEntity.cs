using Domain.Entities;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity<T> : BaseEntity<T>, IAuditableEntity
    {
        public bool IsDeleted { get;set; }
        public DateTime CreatedDate { get ; set ; }
        public DateTime ModifiedDate { get ; set ; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get ; set; }
    }
}
