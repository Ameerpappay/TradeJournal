using Domain.Common;
using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TradeImage : BaseEntity
    {
        public Trade? Trade { get; set; }

        [Required]
        public int TradeId { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public ImageTag ImageTag { get; set; }
    }
}
