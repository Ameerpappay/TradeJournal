using Application;
using Application.Dtos.Portfolio;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Persistance.Context;
using Persistance.UnitOfWork;

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
                await context.SaveChangesAsync();
            }

            var adminEmail = "admin@admin.com";

            if (!context.Users.Any(item => item.Email == adminEmail))
            {
                var userManager = services.GetRequiredService<UserManager<User>>();
                var result = await userManager.CreateAsync(new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                }, "Admin@123"
                );

                var addedUser = await userManager.FindByEmailAsync(adminEmail);

                context.Portfolios.Add(new Portfolio
                {
                    Name = "Default Portfolio",
                    Description = "This is by default",
                    IsSelected = true,
                    IsDefault = true,
                    CreatedByUserId = addedUser.Id,
                    CreatedDate = DateTime.UtcNow
                });
                
                await userManager.AddToRoleAsync(addedUser, Domain.Enum.Role.Admin.ToString());           
                await context.SaveChangesAsync();          
            }
        }
    }
}
