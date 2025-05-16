using Microsoft.EntityFrameworkCore;
using Projeto.Adopet.API;
using Projeto.Adopet.API.Context;
using Projeto.Adopet.API.Service;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

ConfigureLogRequestSerilogExtension.AddSerilogAPI(builder);

//DI
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<IEventoService, EventoService>()
.AddDbContext<DataBaseContext>(opt =>
{
    opt.UseInMemoryDatabase("AdopetDB");
    opt.UseLoggerFactory(LoggerFactory.Create(builder =>
    {
        builder.AddSerilog();
    }));
});

// habilitando o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adicionano os servicos
var app = builder.Build();

// Gera dados fake após a construção do app, usando o provider do app para evitar múltiplas instâncias de singleton
using (var scope = app.Services.CreateScope())
{
    var eventoService = scope.ServiceProvider.GetRequiredService<IEventoService>();
    eventoService.GenerateFakeData();
}

// ativando o swagger
app.UseSwagger();

// ativando a inteface do swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI v1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

// roda a aplicação
app.Run();