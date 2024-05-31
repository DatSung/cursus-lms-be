using Cursus.LMS.API.Extentions;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Mappings;
using Cursus.LMS.Service.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add ApplicationDbContext to the application's services to manage database connections.
// Use SqlServer as the database provider and retrieve the connection string from the configuration.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register Identity service
builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Register services life cycle
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();


// Register SwaggerGen and config for Authorize
builder.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();