using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Dtos.Trade
{
    public class AddTradeDto
    {
        public String Code { get; set; }

        public Decimal Price { get; set; }

        public DateTime EntryDate { get; set; }

        public Decimal Quantity { get; set; }

        public Decimal StopLoss { get; set; }

        public int StrategyId { get; set; }

        public string? Narration { get; set; }    
    }   
}
