using Application;
using Application.IRepositories;
using Application.IServices;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistance.Context;
using Persistance.Repositories;
using Persistance.UnitOfWork;
using System.Text;
using WebApi.BuilderServices;
using WebApi.Extensions;

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
            builder.Services.ConfigureSwagger();

            //repositories
            builder.Services.AddApplicationRepositories();

            //unitofwork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            builder.Services.AddApplicationServices();

            builder.Services.AddDbContext<TradeJournalDataContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("tradejournal")));

            builder.Services.AddCustomIdentity();

            builder.Services.AddJwtAuthentication(builder.Configuration);

            var app = builder.Build();

            app.AddMigrations();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}