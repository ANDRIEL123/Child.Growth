using System.Globalization;
using Child.Growth;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Cria uma instância do Startup
var startup = new Startup(builder.Configuration);

// Adicione serviços ao contêiner.
startup.ConfigureServices(builder.Services);

// Adicione o serviço ITempDataDictionaryFactory
builder.Services.AddSingleton<ITempDataDictionaryFactory, TempDataDictionaryFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.log",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: true,
        outputTemplate: "{Timestamp:dd/MM/yyyy HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    )
    .CreateLogger();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Child.Growth Project", Version = "v1" });

    // Configuração para adicionar o suporte à autenticação Bearer Token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira o Token JWT no formato Bearer",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configura o pipeline de solicitação HTTP.
startup.Configure(app, app.Environment);

app.MapControllers();

app.Run();
