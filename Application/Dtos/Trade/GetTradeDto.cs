using Application.Dtos.Holdings;
using Application.Dtos.Image;
using Domain.Enum;

namespace Application.Dtos.Trade
{
    public class GetTradeDto
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string HoldingsId { get; set; }

        public Decimal Price { get; set; }

        public DateTime EntryDate { get; set; }

        public Decimal Quantity { get; set; }

        public Decimal StopLoss { get; set; }
        public TradeAction Action { get; set; }

        public string StrategyId { get; set; }

        public string? Description { get; set; }

        public GetHoldingsDto holding { get; set; }

        public List<GetImageDto> Images { get; set; }
    }
}
