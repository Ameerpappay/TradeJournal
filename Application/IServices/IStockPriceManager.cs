using Application.Dtos.StockPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public  interface IStockPriceManager
    {
        public GetStockPriceDto GetStockPrice(string stockCode);

        public List<GetStockPriceDto> GetStocksPrice { get; set; }
    }
}
