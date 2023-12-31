using ApplicationCore.Exceptions;
using Domain.Options;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;
using WebApi.Core;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<ContraseniaOptions>(configuration.GetSection("PasswordOptions"));

builder.Services.Configure<AuthenticationOptions>(configuration.GetSection("Authentications"));

builder.Services.AddCors(p => p.AddPolicy(MyAllowSpecificOrigins, builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddCustomSwagger(configuration)
                .AddCustomHealthChecks(configuration)
                .AddCustomSecuritySwagger(configuration)
                .AddCustomIntegrations(configuration);


ConfigureLogging();

builder.Host.UseSerilog();


var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
app.UseSwagger()
   .UseSwaggerUI(c =>
   {
       c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Demo");
       c.OAuthClientId("CofideSeguridadApi");
       c.OAuthAppName("SPB Api");
   });


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();

void ConfigureLogging()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environment}.json", optional: true)
        .Build();

    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        //.Enrich.WithMachineName()
        .Enrich.WithExceptionDetails()
        .WriteTo.Debug()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
        .Enrich.WithProperty("Environment", environment)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}

ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    var nameIndex = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}";
    var uriString = new Uri(configuration["ElasticConfiguration:Uri"]);
    return new ElasticsearchSinkOptions(uriString)
    {
        AutoRegisterTemplate = true,
        IndexFormat = nameIndex,
        //BatchAction = ElasticOpType.Create,
        //AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
        //NumberOfReplicas = 1,
    };
}