using Application;
using Application.IRepositories;
using Application.IServices;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistance.Context;
using Persistance.Repositories;
using Persistance.UnitOfWork;
using System.Net.Mail;
using System.Net;
using System.Text;
using WebApi.BuilderServices;
using WebApi.Error;
using WebApi.ExceptionHandler;
using WebApi.Extensions;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container            
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureSwagger();

            //repositories
            builder.Services.AddApplicationRepositories();

            //unitofwork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IGoogleSheetRepository, GoogleSheetRepository>();

            //Services
            builder.Services.AddApplicationServices();

            builder.Services.AddDbContext<TradeJournalDataContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("tradejournal")));

            builder.Services.AddCustomIdentity();
            builder.Services.AddLogging(logging =>
            {
                logging.ClearProviders();
            });


            builder.Services.AddSingleton<SmtpClient>(provider =>
             {
                 var smtpSettings = provider.GetRequiredService<IConfiguration>().GetSection("SmtpSettings");
                 var smtpClient = new SmtpClient(smtpSettings["Host"])
                 {
                     Port = int.Parse(smtpSettings["Port"]),
                     Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),

                     EnableSsl = bool.Parse(smtpSettings["EnableSsl"]),
                     //DeliveryMethod=SmtpDeliveryMethod.Network,
                     //UseDefaultCredentials = false

                 };
                 return smtpClient;
             });

            // builder.Services.AddIdentity<User, IdentityRole>().AddDefaultTokenProviders();

            builder.Services.AddJwtAuthentication(builder.Configuration);
            builder.Services.AddCors(options => { options.AddPolicy("myPolicy", policy => { policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); });
            var app = builder.Build();
            app.UseCors("myPolicy");

            app.AddMigrations();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ApiExceptionHandler>();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}