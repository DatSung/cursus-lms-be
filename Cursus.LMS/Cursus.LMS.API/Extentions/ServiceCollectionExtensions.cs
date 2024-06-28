using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.DataAccess.Repository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Microsoft.AspNetCore.Identity;

namespace Cursus.LMS.API.Extentions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        // Registering IUnitOfWork with its implementation UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // Registering IBaseService with its implementation BaseService
        services.AddScoped<IBaseService, BaseService>();
        // Registering IAuthService with its implementation AuthService
        services.AddScoped<IAuthService, AuthService>();
        // Registering IEmailService with its implementation EmailService
        services.AddScoped<IEmailService, EmailService>();
        // Registering IEmailSender with its implementation EmailSender
        services.AddScoped<IEmailSender, EmailSender>();
        // Registering ITokenService with its implementation TokenService
        services.AddScoped<ITokenService, TokenService>();
        // Registering IRedisService with its implementation RedisService
        services.AddScoped<IRedisService, RedisService>();
        // Registering ICategoryService with its implementation CategoryService
        services.AddScoped<ICategoryService, CategoryService>();
        // Registering IInstructorService its implementation InstructorService
        services.AddScoped<IInstructorService, InstructorService>();
        // Registering IUserManagerRepository its implementation UserManagerRepository
        services.AddScoped<IUserManagerRepository, UserManagerRepository>();
        // Registering IClosedXMLService its implementation ClosedXMLService
        services.AddScoped<IClosedXMLService, ClosedXMLService>();
        // Registering ICourseService its implementation CourseService
        services.AddScoped<ICourseService, CourseService>();
        // Registering ICourseVersionService its implementation CourseVersionService
        services.AddScoped<ICourseVersionService, CourseVersionService>();

        // Register the Identity services with default configuration
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}