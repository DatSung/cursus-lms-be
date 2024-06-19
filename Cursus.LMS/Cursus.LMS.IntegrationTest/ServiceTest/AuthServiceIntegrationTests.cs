using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Moq;
using AutoMapper;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Cursus.LMS.API;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Service.Service;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Cursus.LMS.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
namespace Cursus.LMS.IntegrationTest
{
    public class AuthServiceIntegrationTests<TProgram>: WebApplicationFactory<TProgram> where TProgram : class

    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            builder.ConfigureServices(services =>
            {
                var context = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ApplicationDbContext));
                if (context != null)
                {
                    services.Remove(context);
                    var options = services.Where(r => r.ServiceType == typeof(DbContextOptions)
                      || r.ServiceType.IsGenericType && r.ServiceType.GetGenericTypeDefinition() == typeof(DbContextOptions<>)).ToArray();
                    foreach (var option in options)
                    {
                        services.Remove(option);
                    }
                }

                // Add a new registration for ApplicationDbContext with an in-memory database
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    // Provide a unique name for your in-memory database
                    options.UseInMemoryDatabase("InMemoryDatabaseNameX");
                });
            });
        }
    }

}

