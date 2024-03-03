using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Persistance.Context;

namespace WebApi.Extensions
{
    public static class IdentityExtensions
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<TradeJournalDataContext>();
        }
    }
}
