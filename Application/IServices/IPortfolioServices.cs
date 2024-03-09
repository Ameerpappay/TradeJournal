using Application.Dtos.Strategy;
using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Portfolio;

namespace Application.IServices
{
    public interface IPortfolioServices
    {
        Task<List<GetPortfolioDto>> GetPortfolio();

        Task<GetPortfolioDto> AddPortfolio(AddPortfolioDto portfolio);

        Task<GetPortfolioDto> GetPortfolioById(int portfolioId);

        Task UpdatePortfolio(int Id, UpdatePortfolioDto updatePortfolioDto);

        Task DeletePortfolioById(int portfolioId);
    }
}
