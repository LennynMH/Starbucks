using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace WebApi.Core
{
    public static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomMVC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                //options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(gen =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                gen.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                gen.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
                gen.CustomSchemaIds(i => i.FullName);
                gen.DescribeAllParametersInCamelCase();
                gen.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            return services;
        }

        public static IServiceCollection AddCustomSecuritySwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentications:Issuer"],
                    ValidAudience = configuration["Authentications:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentications:SecretKey"]))
                };

            });
            return services;
        }

        public static IApplicationBuilder UseCustomHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/status", new HealthCheckOptions()
            {
                Predicate = r => r.Name.Contains("self")
            });
            app.UseHealthChecks("/api/check", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = new Func<HttpContext, HealthReport, Task>(UIResponseWriter.WriteHealthCheckUIResponse)
            });
            return app;
        }

        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

            return services;
        }

        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<IJsonWebTokenService, JsonWebTokenService>();
            return services;
        }
    }
}
