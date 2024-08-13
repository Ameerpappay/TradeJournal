using Application.IRepositories;
using Persistance.Repositories;

namespace WebApi.Extensions
{
    public static class ApplicationRepositoryExtensions
    {
        public static void AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStrategyRepository, StrategyRepository>();
            services.AddScoped<ITradeRepository, TradeRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IHoldingsRepository, HoldingsRepository>();
            services.AddScoped<IStocksDetailsRepository, GoogleSheetRepository>();
            services.AddScoped<IExcelSheetRepository, ExcelSheetRepository>();

        }
    }
}
