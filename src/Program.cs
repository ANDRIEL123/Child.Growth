using Child.Growth;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var startup = new Startup(builder.Configuration); // Cria uma instância do Startup

// Adicione serviços ao contêiner.
startup.ConfigureServices(builder.Services);

// Adicione o serviço ITempDataDictionaryFactory
builder.Services.AddSingleton<ITempDataDictionaryFactory, TempDataDictionaryFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de solicitação HTTP.
startup.Configure(app, app.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
