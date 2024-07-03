using Cursus.LMS.API.Extentions;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Service.Hubs;
using Cursus.LMS.Service.Mappings;
using Cursus.LMS.Utility.Constants;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add ApplicationDbContext to the application's services to manage database connections.
// Use SqlServer as the database provider and retrieve the connection string from the configuration.

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(StaticConnectionString.SQLDB_DefaultConnection));
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

var app = builder.Build();

ApplyMigration();

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


app.UseHangfireDashboard();

app.MapHangfireDashboard("/hangfire");

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