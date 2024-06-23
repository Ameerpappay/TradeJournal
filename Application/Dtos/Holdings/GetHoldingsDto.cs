using Application.Dtos.Trade;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Holdings
{
    public class GetHoldingsDto
    {
        public int Id { get; set; } 
        public string Identifier { get; set; }
        public string Code { get; set; }

        public decimal Quantity { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal TrailingStoploss { get; set; }

        public int PortfolioId { get; set; }
        public List<GetTradeDto> Trades { get; set; }


    }
}
