using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Adopet.API.Context;
using Projeto.Adopet.API.Domain;
using Serilog;

namespace Projeto.Adopet.API.Controller;

[ApiController]
[Route("/pet/")]
public class PetController : ControllerBase
{
    [HttpGet]
    [Route("list")]
    public async Task<IResult> ListaDePet()
    {
        var _logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("AdoPetAPI-Actions-logs.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

        var options = new DbContextOptionsBuilder<DataBaseContext>()
        .UseInMemoryDatabase("AdopetDB")
        .Options;

        try
        {
            DataBaseContext _context = new(options);
            var pets = await _context.Pets.Include(x => x.Proprietario).ToListAsync();

            return Results.Ok(pets);
        }
        catch (System.Exception ex)
        {
            _logger.Error(ex, "Ocorreu um erro:", ex.Message);
        }

        return Results.Ok();
    }

    [HttpPost]
    [Route("add")]
    public async Task<IResult> CadastrarPet([FromBody] Pet pet)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

        string _date = DateTime.Now.ToString("yyyy-MM-dd_HH");
        string? path = configuration["LoggerBasePath"];
        string? template = configuration["LoggerFileTemplate"] ?? "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"; ;
        string filename = $@"{path}/{_date}.adopet.log";

        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File(filename, outputTemplate: template)
        .CreateLogger();

        var options = new DbContextOptionsBuilder<DataBaseContext>()
        .UseInMemoryDatabase("AdopetDB")
        .Options;

        try
        {
            DataBaseContext _context = new(options);
            await _context.Pets.AddAsync(pet);
            _context.SaveChanges();

            Log.Information("Pet cadastrado com sucesso!");
        }
        catch (System.Exception ex)
        {
            Log.Error(ex, "Ocorreu um erro:", ex.Message);
        }
        finally
        {
            Log.CloseAndFlush();
        }

        return Results.Ok();
    }
}
