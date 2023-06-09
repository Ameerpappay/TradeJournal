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

        public Task Save(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
