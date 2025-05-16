using System;
using Microsoft.EntityFrameworkCore;
using Projeto.Adopet.API.Domain;

namespace Projeto.Adopet.API.Context;

public class DataBaseContext : DbContext
{

    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pet> Pets { get; set; }
}
