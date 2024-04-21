using Application;
using Application.IRepositories;
using Application.IServices;
using Microsoft.EntityFrameworkCore.Storage;
using Persistance.Context;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TradeJournalDataContext _dbContext;

        public IStrategyRepository StrategyRepository { get; set; }

        public ITradeRepository TradeRepository { get; set; }

        public IImageRepository ImageRepository { get; set; }

        public IPortfolioRepository PortfolioRepository { get; set; }

        public IHoldingsRepository HoldingsRepository { get; set; }

        public UnitOfWork(TradeJournalDataContext context, IStrategyRepository strategyRepository, ITradeRepository tradeRepository, IImageRepository imageRepository, IPortfolioRepository portfolioRepository, IHoldingsRepository holdingsRepository)
        {
            _dbContext = context;
            StrategyRepository = strategyRepository;
            TradeRepository = tradeRepository;
            ImageRepository = imageRepository;
            PortfolioRepository = portfolioRepository;
            HoldingsRepository = holdingsRepository;
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
