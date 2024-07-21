using Application.Dtos.Trade;
using Application.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class TradeRepository : GenericRepository<Trade>, ITradeRepository
    {
        private TradeJournalDataContext _dbContext;
        private DbSet<Trade> _dbSet;
        public TradeRepository(TradeJournalDataContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<Trade>();
        }

        public async override Task<Trade> Get(string id, string createdById)
        {
            var result = await _dbSet.Include(i => i.Holdings).Include(s => s.Strategy).Include(i => i.Images).FirstOrDefaultAsync(x => x.Identifier.ToString() == id && !x.IsDeleted);

            return result;
        }

        public override async Task<IEnumerable<Trade>> Get(string createdById)
        {
            var result = await _dbSet.Include(h => h.Holdings).Include(s => s.Strategy).Include(i => i.Images).Where(x => !x.IsDeleted && x.CreatedByUserId == createdById).ToListAsync();

            return result;
        }

        public Task<IEnumerable<GetTradeDto>> GetTradesByHolidingID(string userId, string holdingId)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Trade>> ITradeRepository.Get(string createdById, int portfolioId)
        {
            var result = await _dbSet.Include(h => h.Holdings).Include(s => s.Strategy).Include(i => i.Images).Where(x => !x.IsDeleted && x.CreatedByUserId == createdById && x.Holdings.PortfolioId == portfolioId).ToListAsync();
            return result;
        }
    }
}
