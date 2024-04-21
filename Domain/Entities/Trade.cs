using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Trade : BaseEntity
    {
        [Required]
        public int HoldingsId { get; set; }

        public Holding? Holdings { get; set; }

        public Decimal Price { get; set; }

        public DateTime EntryDate { get; set; }

        public Decimal Quantity { get; set; }

        public Decimal StopLoss { get; set; }

        [Required]
        public int StrategyId { get; set; }

        public Strategy? Strategy { get; set; }

        public string? Description { get; set; }

        public List<TradeImage>? Images { get; set; }

       
    }
}
