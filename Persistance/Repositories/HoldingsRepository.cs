using Application.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class HoldingsRepository : GenericRepository<Holding>, IHoldingsRepository
    {
        TradeJournalDataContext _dbContext;
        public HoldingsRepository(TradeJournalDataContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Holding> GetExistingHolding(string code, int portfolioId)
        {
            Holding availTrade = await this._dbContext.Holdings.SingleOrDefaultAsync(item => item.StockCode == code && item.Quantity > 0 && item.Id == portfolioId);
            return availTrade;
        }
    }
}
