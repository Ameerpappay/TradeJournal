using Application;
using Application.IRepositories;
using Application.IServices;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Repositories;
using Persistance.UnitOfWork;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //repositories
            builder.Services.AddScoped<IStrategyRepository, StrategyRepository>();
            builder.Services.AddScoped<ITradeRepository, TradeRepository>();

            //unitofwork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            builder.Services.AddScoped<IStrategyService, StrategyService>();
            builder.Services.AddScoped<ITradeServices, TradeServices>();


            builder.Services.AddDbContext<TradeJournalDataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("tradejournal")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}