using Domain.Common;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image:BaseEntity
    {
        public Trade Trade { get; set; }

        public int TradeId { get; set; }

        public string ImageUrl { get; set; }

        public ImageTag ImageTag { get; set; }       
    }
}
