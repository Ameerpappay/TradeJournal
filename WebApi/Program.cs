using Application;
using Application.IRepositories;
using Application.IServices;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistance.Context;
using Persistance.Repositories;
using Persistance.UnitOfWork;
using System.Text;

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
            builder.Services.AddScoped<IImageRepository, ImageRepository>();

            //unitofwork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            builder.Services.AddScoped<IStrategyService, StrategyService>();
            builder.Services.AddScoped<ITradeServices, TradeServices>();
            builder.Services.AddScoped<IImageService, Imageservice>();
            builder.Services.AddScoped<IUserAccountService, UserAccountService>();

            builder.Services.AddDbContext<TradeJournalDataContext>(options =>    
            options.UseNpgsql(builder.Configuration.GetConnectionString("tradejournal")));

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<TradeJournalDataContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer" ],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };

            });


            var app = builder.Build();
            
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