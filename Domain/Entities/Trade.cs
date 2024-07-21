using Domain.Common;
using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Trade : BaseEntity
    {
        [Required]
        public int HoldingsId { get; set; }

        public virtual Holding Holdings { get; set; }

        //public string Action {  get; set; }

        public Decimal Price { get; set; }

        public TradeAction Action { get; set; }

        public DateTime EntryDate { get; set; }

        public Decimal Quantity { get; set; }

        public Decimal StopLoss { get; set; }

        [Required]
        public int StrategyId { get; set; }

        public virtual Strategy? Strategy { get; set; }

        public string? Description { get; set; }

        public virtual List<TradeImage>? Images { get; set; }
    }
}
