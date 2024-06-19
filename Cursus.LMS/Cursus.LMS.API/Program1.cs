using Cursus.LMS.API.Extentions;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Service.Mappings;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace Cursus.LMS.API.csproj
{
    public class Program1
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add ApplicationDbContext to the application's services to manage database connections.
            // Use SqlServer as the database provider and retrieve the connection string from the configuration.

            builder.Services.AddControllers();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddHttpClient();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(StaticConnectionString.SQLDB_TrongConnection));
            });

            // Set time token
            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromMinutes(15));

            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            // Register services life cycle
            // Base on Extensions.ServiceCollectionExtensions
            builder.Services.RegisterServices();

            // Register firebase services life cycle
            // Base on Extensions.FirebaseServiceExtensions
            builder.Services.AddFirebaseServices();

            // Register redis services life cycle
            // Base on Extensions.RedisServiceExtensions
            builder.AddRedisCache();

            builder.Services.AddEndpointsApiExplorer();

            // Register Authentication
            // Base on Extensions.WebApplicationBuilderExtensions
            builder.AddAppAuthentication();

            builder.Services.AddAuthorization();

            // Register SwaggerGen and config for Authorize
            // Base on Extensions.WebApplicationBuilderExtensions
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(options =>
            {
                options
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
