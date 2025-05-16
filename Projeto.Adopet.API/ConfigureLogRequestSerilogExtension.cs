using System;
using Serilog;

namespace Projeto.Adopet.API;

public static class ConfigureLogRequestSerilogExtension
{
    public static void AddSerilogAPI(this WebApplicationBuilder builder)
    {
        string _date = DateTime.Now.ToString("yyyy-MM-dd_HH");
        string? path = builder.Configuration.GetSection("LoggerBasePath").Value;
        string? template = builder.Configuration.GetSection("LoggerFileTemplate").Value;
        string filename = $@"{path}/{_date}.adopet.log";

        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File(filename, outputTemplate: template)
        .CreateLogger();

        builder.Host.UseSerilog(Log.Logger);
    }

}
