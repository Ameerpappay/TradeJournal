using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Holdings:BaseEntity
    {
        public string Code { get; set; }

        public decimal Quantity { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal TrailingStoploss { get; set; }

        public int PortfolioId { get; set; }

        public Portfolio Portfolio { get; set; }
        
        public List<Trade> Trades { get; set; } 

    }
}
