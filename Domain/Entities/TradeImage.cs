using Domain.Common;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TradeImage:BaseEntity
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
