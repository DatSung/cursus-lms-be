//using Cursus.LMS.API.Extentions;
//using Cursus.LMS.DataAccess.Context;
//using Cursus.LMS.Service.Hubs;
//using Cursus.LMS.Service.Mappings;
//using Cursus.LMS.Utility.Constants;
//using Hangfire;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.OpenApi.Models;
//using System;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Cursus.LMS.API.csproj
//{
//    public class Program1
//    {
//        public static async Task Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container
//            builder.Services.AddControllers();
//            builder.Services.AddHttpContextAccessor();
//            builder.Services.AddHttpClient();

//            builder.Services.AddDbContext<ApplicationDbContext>(options =>
//            {
//                options.UseSqlServer(builder.Configuration.GetConnectionString(StaticConnectionString.SQLDB_TrongConnection));
//            });

//            // Set token lifespan
//            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
//                options.TokenLifespan = TimeSpan.FromMinutes(15));

//            // Register AutoMapper
//            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//            // Register custom services
//            builder.Services.RegisterServices();
//            builder.Services.AddFirebaseServices();
//            builder.AddRedisCache();
//            builder.AddHangfireServices();

//            builder.Services.AddEndpointsApiExplorer();

//            // Register Authentication and Authorization
//            builder.AddAppAuthentication();
//            builder.Services.AddAuthorization();

//            // Register Swagger
//            builder.Services.AddSwaggerGen();

//            // Register SignalR
//            builder.Services.AddSignalR();

//            // Register CORS
//            builder.Services.AddCors(options =>
//            {
//                var origin = builder.Configuration["AllowOrigin:FrontEnd"];
//                options.AddPolicy("AllowSpecificOrigin",
//                    builder => builder
//                        .WithOrigins(origin)
//                        .AllowAnyHeader()
//                        .AllowAnyMethod()
//                        .AllowCredentials());
//            });

//            var app = builder.Build();

//            // Configure the HTTP request pipeline
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseCors("AllowSpecificOrigin");
//            app.UseHangfireDashboard();
//            app.MapHangfireDashboard("/hangfire");
//            app.UseHttpsRedirection();
//            app.UseAuthentication();
//            app.UseAuthorization();
//            app.MapControllers();
//            app.MapHub<NotificationHub>("/hubs/notification").RequireAuthorization();

//            // Apply migrations
//            ApplyMigration(app);

//            app.Run();
//        }

//        private static void ApplyMigration(WebApplication app)
//        {
//            using (var scope = app.Services.CreateScope())
//            {
//                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//                if (context.Database.GetPendingMigrations().Any())
//                {
//                    context.Database.Migrate();
//                }
//            }
//        }
//    }
//}
