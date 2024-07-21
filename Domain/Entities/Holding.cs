using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Holding : BaseEntity
    {
        [Required]
        public string StockCode { get; set; }

        public decimal Quantity { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal TrailingStoploss { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        public Portfolio? Portfolio { get; set; }

        public virtual List<Trade> Trades { get; set; } = new List<Trade> { };

    }
}
