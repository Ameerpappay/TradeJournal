using Application.Dtos.Portfolio;
using Domain.Entities;

namespace Application.IRepositories
{
    public interface IPortfolioRepository : IGenericRepository<Portfolio>
    {
        public Task<GetPortfolioDto> SelectedPortfolio(string userId);

        public void SetSelectedPortfolio(string userId, string portfolioId);

    }
}
