using Application.IRepositories;

namespace Application
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
        IStrategyRepository StrategyRepository { get; }

        ITradeRepository TradeRepository { get; }

        IImageRepository ImageRepository { get; }

        IPortfolioRepository PortfolioRepository { get; }

        IHoldingsRepository HoldingsRepository { get; }
        IExcelSheetRepository ExcelSheetRepository { get; }
    }
}
