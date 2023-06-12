using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Trade:BaseEntity
    {
        public String Code { get; set; }
        public Decimal Price { get; set; }
        public DateTime EntryDate { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal StopLoss { get; set; }
        public Strategy Strategy { get; set; }
        public string Narration { get; set; }
    }
}
