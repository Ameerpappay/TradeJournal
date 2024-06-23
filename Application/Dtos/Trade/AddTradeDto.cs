using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Image;
using Domain.Common;
using Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos.Trade
{
    public class AddTradeDto
    {
        //public int HoldingsId { get; set; }

        public string Code {  get; set; }

        public Decimal Price { get; set; }

        public DateTime EntryDate { get; set; }

        public Decimal Quantity { get; set; }

        public Decimal StopLoss { get; set; }

        public TradeAction  Action { get; set; }

        public string StrategyId { get; set; }

        public string? Description { get; set; }    

        public List<UploadImageDto>? Images { get; set; }

       // public string PortfolioId {  get; set; }
    }
    
    public class UploadImageDto
    {
        public IFormFile ImageFile { get; set; }
        public ImageTagDto ImageTag { get; set; }
    }
}
