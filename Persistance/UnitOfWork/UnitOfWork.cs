using Application;
using Application.IRepositories;
using Persistance.Context;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TradeJournalDataContext _dbContext;

        public IStrategyRepository StrategyRepository { get; set; }

        public UnitOfWork(TradeJournalDataContext context, IStrategyRepository strategyRepository)
        {
            _dbContext = context;
            StrategyRepository = strategyRepository;
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
