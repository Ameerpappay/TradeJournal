using Application.Dtos.Portfolio;
using Application.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        TradeJournalDataContext _dbContext;
        public PortfolioRepository(TradeJournalDataContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<GetPortfolioDto> SelectedPortfolio(string userId)
        {
            Portfolio selectedPortfolio = await _dbContext.Set<Portfolio>().FirstOrDefaultAsync(p => p.IsSelected && p.CreatedByUserId == userId);

            return new GetPortfolioDto
            {
                Identifier = selectedPortfolio.Identifier.ToString(),
                PortfolioId = selectedPortfolio.Id,
                Name = selectedPortfolio.Name,
                Description = selectedPortfolio.Description,
            };
        }

        public void SetSelectedPortfolio(string userId, string portfolioId)
        {
            var portfolioToUpdate = _dbContext.Set<Portfolio>().FirstOrDefault(p => p.Identifier.ToString() == portfolioId);
            if (portfolioToUpdate != null)
            {
                portfolioToUpdate.IsSelected = true;
            }
            var otherPortfolios = _dbContext.Set<Portfolio>().Where(p => p.Identifier.ToString() != portfolioId).ToList();
            foreach (var portfolio in otherPortfolios)
            {
                portfolio.IsSelected = false;
            }
            _dbContext.SaveChanges();
        }
    }
}
