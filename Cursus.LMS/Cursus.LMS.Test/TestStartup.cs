using Cursus.LMS.API;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Service.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Service.Mappings;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;

namespace Cursus.LMS.Test
{
    public class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddHttpClient();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestDatabase"));

            services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromMinutes(15));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            // Add your services here directly
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseReviewService, CourseReviewService>();
            services.AddScoped<ICourseReportService, CourseReportService>();
            services.AddScoped<ICourseProgressService, CourseProgressService>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSignalR();

            services.AddCors(options =>
            {
                var originDefault = Configuration["AllowOrigin:FrontEnd"];
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins(originDefault)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowSpecificOrigin");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/hubs/notification").RequireAuthorization();
            });
        }
    }
}
