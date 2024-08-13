using Application.Dtos.Trade;

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
