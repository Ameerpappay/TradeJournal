using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Holdings
{
    public class AddHoldingsDto
    {
        public string Code { get; set; }

        public decimal Quantity { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal TrailingStoploss { get; set; }

        public string PortfolioId { get; set; }

    }
}
