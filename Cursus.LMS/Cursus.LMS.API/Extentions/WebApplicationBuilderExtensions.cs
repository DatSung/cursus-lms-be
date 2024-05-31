using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Cursus.LMS.API.Extentions;

public static class WebApplicationBuilderExtensions
{
    // public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
    // {
    //     builder.Services.AddAuthentication(options =>
    //     {
    //         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //     }).AddJwtBearer(options =>
    //     {
    //         options.TokenValidationParameters = new TokenValidationParameters()
    //         {
    //             ValidateIssuerSigningKey = true,
    //             IssuerSigningKey =
    //                 new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["ApiSettings:Secret"])),
    //             ValidateIssuer = true,
    //             ValidateAudience = true,
    //             ValidIssuer = builder.Configuration["ApiSettings:Issuer"],
    //             ValidAudience = builder.Configuration["ApiSettings:Audience"]
    //         };
    //     });
    //
    //     return builder;
    // }
    
    public static WebApplicationBuilder AddSwaggerGen(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Description = "Bearer_[your-token]",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    new string[] { }
                }
            });
        });
        
        return builder;
    }
}