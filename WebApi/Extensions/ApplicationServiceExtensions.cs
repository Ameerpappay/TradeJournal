using Application.Dtos;
using Application.IServices;
using Application.IServices.ICacheServices;
using Application.Services;
using Application.Services.CacheServices;

namespace WebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //services
            services.AddScoped<IStrategyService, StrategyService>();
            services.AddScoped<ITradeServices, TradeServices>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IPortfolioServices, PortfolioService>();
            services.AddScoped<IHoldingsServices, HoldingsService>();
            services.AddScoped<IStockDetailsService,StockDetailsService>();

            //cache
            services.AddScoped(typeof(ICacheService<>), typeof(InMemoryCacheService<>));
            services.AddScoped<IStocksDetailsCacheService, StockDetailsCacheService>();
        }
    }
}
