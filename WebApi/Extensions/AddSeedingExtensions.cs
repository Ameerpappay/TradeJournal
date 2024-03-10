using Application.Dtos;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Persistance.Context;

namespace WebApi.Extensions
{
    public static class AddSeedingExtensions
    {
        public static async void AddMigrations(this IApplicationBuilder app)
        {
            var services = app.ApplicationServices.CreateScope().ServiceProvider;
            var context = services.GetRequiredService<TradeJournalDataContext>();

            if (!context.Roles.Any(item => item.Name == "Admin"))
            {
                context.Roles.Add(new IdentityRole { Name = "Admin", ConcurrencyStamp = Guid.NewGuid().ToString(), NormalizedName = "ADMIN" });
                await context.SaveChangesAsync();
            }
            if (!context.Roles.Any(item => item.Name == "Trader"))
            {
                context.Roles.Add(new IdentityRole { Name = "Trader", ConcurrencyStamp = Guid.NewGuid().ToString(), NormalizedName = "TRADER" });
               await  context.SaveChangesAsync();
            }

            if (!context.Users.Any(item => item.Email == "admin@admin.com"))
            {
                var userAccountService = services.GetRequiredService<IUserAccountService>();

                await userAccountService.CreateAdmin(new CreateUserDto
                {
                    Email = "admin@admin.com",
                    Password = "Admin@123"
                });
            }
        }
    }
}
