using Cursus.LMS.API.Extentions;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Service.Hubs;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Mappings;
using Cursus.LMS.Utility.Constants;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add ApplicationDbContext to the application's services to manage database connections.
// Use SqlServer as the database provider and retrieve the connection string from the configuration.

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(StaticConnectionString.SQLDB_DefaultConnection));
});

// Set time token
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
    options.TokenLifespan = TimeSpan.FromMinutes(60));

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

// Register hangfire services life cycle
// Base on Extensions.HangfireServiceExtensions
builder.AddHangfireServices();

builder.Services.AddEndpointsApiExplorer();

// Register Authentication
// Base on Extensions.WebApplicationBuilderExtensions
builder.AddAppAuthentication();

builder.Services.AddAuthorization();

// Register SwaggerGen and config for Authorize
// Base on Extensions.WebApplicationBuilderExtensions
builder.AddSwaggerGen();

// Register SignalR
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    var originDefault = builder.Configuration["AllowOrigin:FrontEnd"];
    var originFirebase = builder.Configuration["AllowOrigin:FrontEndFirebase"];
    var originVercel = builder.Configuration["AllowOrigin:FrontEndVercel"];
    var originK8S = builder.Configuration["AllowOrigin:FrontEndK8S"];
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins(originDefault, originFirebase, originVercel, originK8S)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

// Add Application Insights Telemetry
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["ApplicationInsights:ConnectionString"]);

var app = builder.Build();

ApplyMigration();

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHangfireDashboard();

app.MapHangfireDashboard("/hangfire");

RecurringJob.AddOrUpdate<IAuthService>(job => job.SendClearEmail(3), "0 0 1 */3 *");
RecurringJob.AddOrUpdate<IAuthService>(job => job.ClearUser(), "0 0 1 */4 *");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/hubs/notification").RequireAuthorization();

app.Run();

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}