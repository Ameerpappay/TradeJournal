using Application.IRepositories;
using Domain.Entities;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
