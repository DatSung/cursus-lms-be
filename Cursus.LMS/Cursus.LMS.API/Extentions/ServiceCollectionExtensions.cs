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
        // Registering ICourseVersionStatusService its implementation CourseVersionStatusService
        services.AddScoped<ICourseVersionStatusService, CourseVersionStatusService>();
        // Registering ICourseSectionVersionService its implementation CourseSectionVersionService
        services.AddScoped<ICourseSectionVersionService, CourseSectionVersionService>();
        // Registering ISectionDetailsVersionService its implementation SectionDetailsVersionService
        services.AddScoped<ISectionDetailsVersionService, SectionDetailsVersionService>();
        // Registering ILevelService its implementation LevelService
        services.AddScoped<ILevelService, LevelService>();
        // Registering IEmailSender its implementation EmailSender
        services.AddScoped<IEmailSender, EmailSender>();
        // Registering ICartService its implementation CartService
        services.AddScoped<ICartService, CartService>();
        // Registering ICourseReviewRepository its implementation CourseReviewRepository
        services.AddScoped<ICourseReviewService, CourseReviewService>();
        // Registering ICourseReviewRepository its implementation CourseReviewRepository
        services.AddScoped<ICourseReportService, CourseReportService>();
        // Registering IOrderService its implementation OrderService
        services.AddScoped<IOrderService, OrderService>();
        // Registering IOrderStatusService its implementation OrderStatusService
        services.AddScoped<IOrderStatusService, OrderStatusService>();
        // Registering IStudentsService its implementation StudentsService
        services.AddScoped<IStudentsService, StudentService>();
        // Registering IStudentCourseService its implementation StudentCourseService
        services.AddScoped<IStudentCourseService, StudentCourseService>();
        // Registering IStudentCourseStatusService its implementation StudentCourseStatusService
        services.AddScoped<IStudentCourseStatusService, StudentCourseStatusService>();
        // Registering IStripeService its implementation StripeService
        services.AddScoped<IStripeService, StripeService>();
        // Registering ITransactionService its implementation TransactionService
        services.AddScoped<ITransactionService, TransactionService>();
        // Registering IBalanceService its implementation BalanceService
        services.AddScoped<IBalanceService, BalanceService>();
        // Registering IPaymentService its implementation PaymentService
        services.AddScoped<IPaymentService, PaymentService>();
        // Registering ICourseProgressService its implementation CourseProgressService
        services.AddScoped<ICourseProgressService, CourseProgressService>();
        // Registering ICompanyService its implementation CompanyService
        services.AddScoped<ICompanyService, CompanyService>();
        // Registering ITermOfUseService its implementation TermOfUseService
        services.AddScoped<ITermOfUseService, TermOfUseService>();
        // Registering IPrivacyService its implementation PrivacyService
        services.AddScoped<IPrivacyService, PrivacyService>();

        // Register the Identity services with default configuration
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


        return services;
    }
}