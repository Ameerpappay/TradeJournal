using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Image
{
    public class AddImageDto
    {
        public int TradeId  { get; set; }

        public Domain.Enum.ImageTag imageTag { get; set; }
    }
}
