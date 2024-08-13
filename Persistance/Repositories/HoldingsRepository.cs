using Application.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class HoldingsRepository : GenericRepository<Holding>, IHoldingsRepository
    {
        TradeJournalDataContext _dbContext;
        private DbSet<Holding> _dbSet;

        public HoldingsRepository(TradeJournalDataContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<Holding>();
        }

        public override async Task<IEnumerable<Holding>> Get(string createdById)
        {
            var result = await _dbContext.Holdings.Include(i => i.Trades).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Holding>> Get(string userId, int portfolioId)
        {
            var result = await _dbContext.Holdings.Include(i => i.Trades).Where(h => h.PortfolioId == portfolioId).ToListAsync();
            return result;
        }

        public async Task<Holding> GetExistingHolding(string code, int portfolioId)
        {
            Holding availTrade = await this._dbContext.Holdings.FirstOrDefaultAsync(item => item.StockCode == code && item.Quantity > 0 && item.PortfolioId == portfolioId);
            return availTrade;
        }
    }
}
