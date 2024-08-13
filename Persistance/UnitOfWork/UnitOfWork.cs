using Application;
using Application.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;
using Persistance.Context;


namespace Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TradeJournalDataContext _dbContext;

        private IDbContextTransaction _transaction;

        public IStrategyRepository StrategyRepository { get; set; }

        public ITradeRepository TradeRepository { get; set; }

        public IImageRepository ImageRepository { get; set; }

        public IPortfolioRepository PortfolioRepository { get; set; }

        public IHoldingsRepository HoldingsRepository { get; set; }
        public IExcelSheetRepository ExcelSheetRepository { get; set; }


        public UnitOfWork(TradeJournalDataContext context, IStrategyRepository strategyRepository, ITradeRepository tradeRepository, IImageRepository imageRepository, IPortfolioRepository portfolioRepository, IHoldingsRepository holdingsRepository , IExcelSheetRepository excelSheetRepository)
        {
            _dbContext = context;
            StrategyRepository = strategyRepository;
            TradeRepository = tradeRepository;
            ImageRepository = imageRepository;
            PortfolioRepository = portfolioRepository;
            HoldingsRepository = holdingsRepository;
            ExcelSheetRepository = excelSheetRepository;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync();
                }
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
