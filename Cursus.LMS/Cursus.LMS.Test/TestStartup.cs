//using Cursus.LMS.API;
//using Cursus.LMS.DataAccess.Context;
//using Cursus.LMS.Model.Domain;
//using Cursus.LMS.Service.Mappings;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Linq;

//namespace Cursus.LMS.Test
//{
//    public class TestStartup
//    {
//        public TestStartup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddControllers();

//            // Use InMemory Database for testing
//            services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseInMemoryDatabase("TestDatabase"));

//            // Register other services needed for testing
//            services.AddAutoMapper(typeof(AutoMapperProfile));

//            // Register additional services or replace existing ones if necessary
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseRouting();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }
//    }
//}
