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
    public class HoldingsRepository: GenericRepository<Holdings>, IHoldingsRepository
    {
        TradeJournalDataContext _dbContext;
        public HoldingsRepository(TradeJournalDataContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
