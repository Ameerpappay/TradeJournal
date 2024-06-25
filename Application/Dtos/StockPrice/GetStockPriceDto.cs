using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.StockPrice
{
    public class GetStockPriceDto
    {
        public string StockCode { get; set; }

        public float StockPrice { get; set; }
    }
}
