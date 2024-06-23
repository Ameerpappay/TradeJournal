using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Portfolio
{
    public class GetPortfolioDto
    {
        public int PortfolioId { get; set; }
        public string Identifier { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
