using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Trade
{
    public class UpdateTradeDto
    {
        public string HoldingsId { get; set; }

        public string Code {  get; set; }

        public Decimal Price { get; set; }

        public DateTime EntryDate { get; set; }

        public Decimal Quantity { get; set; }

        public Decimal StopLoss { get; set; }

        public TradeAction Action { get; set; }

        public string StrategyId { get; set; }

        public string? Description { get; set; }

        public List<UploadImageDto>? Images { get; set; }

        public string PortfolioId { get; set; }
    }
}
