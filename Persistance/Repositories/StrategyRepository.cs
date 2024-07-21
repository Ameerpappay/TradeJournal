using Application.IRepositories;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class StrategyRepository : GenericRepository<Strategy>, IStrategyRepository
    {
        private TradeJournalDataContext _dbContext;
        public StrategyRepository(TradeJournalDataContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
