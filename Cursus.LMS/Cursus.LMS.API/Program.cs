using Cursus.LMS.API.Extentions;
using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.Service.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add ApplicationDbContext to the application's services to manage database connections.
// Use SqlServer as the database provider and retrieve the connection string from the configuration.

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Register services life cycle
// Base on Extensions.ServiceCollectionExtensions
builder.Services.RegisterServices();

// Register firebase services life cycle
// Base on Extensions.FirebaseServiceExtensions
builder.Services.AddFirebaseServices();

builder.Services.AddEndpointsApiExplorer();

// Register Authentication
// Base on Extensions.WebApplicationBuilderExtensions
builder.AddAppAuthentication();

builder.Services.AddAuthorization();

// Register SwaggerGen and config for Authorize
// Base on Extensions.WebApplicationBuilderExtensions
builder.AddSwaggerGen();

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