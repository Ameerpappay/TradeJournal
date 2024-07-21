﻿namespace Application.Dtos.Holdings
{
    public class AddHoldingsDto
    {
        public string Code { get; set; }

        public decimal Quantity { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal TrailingStoploss { get; set; }

        public int PortfolioId { get; set; }

    }
}
