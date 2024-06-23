using Application.Dtos.Portfolio;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IPortfolioRepository : IGenericRepository<Portfolio>
    {
        public   Task<GetPortfolioDto> SelectedPortfolio(string userId);

        public void SetSelectedPortfolio(string userId,string portfolioId);

    }
}
