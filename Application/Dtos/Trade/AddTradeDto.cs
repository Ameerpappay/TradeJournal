using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Image;
using Domain.Common;
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

        public int StrategyId { get; set; }

        public string? Narration { get; set; }    

        public List<UploadImageDto> Images { get; set; }

        public string PortfolioId {  get; set; }
    }
    
    public class UploadImageDto
    {
        public IFormFile Image { get; set; }
        public ImageTagDto ImageTag { get; set; }
    }
}
