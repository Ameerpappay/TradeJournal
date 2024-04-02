using Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();

        IStrategyRepository StrategyRepository { get; }

        ITradeRepository TradeRepository { get; }
        
        IImageRepository ImageRepository { get; }
        IPortfolioRepository PortfolioRepository { get; }
        IHoldingsRepository HoldingsRepository { get; }
    }
}
