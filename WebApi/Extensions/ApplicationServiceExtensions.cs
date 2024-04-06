using Application.IServices;
using Application.Services;

namespace WebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStrategyService, StrategyService>();
            services.AddScoped<ITradeServices, TradeServices>();
            services.AddScoped<IImageService, Imageservice>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IPortfolioServices, PortfolioService>();
            services.AddScoped<IHoldingsServices, HoldingsService>();

        }
    }
}
