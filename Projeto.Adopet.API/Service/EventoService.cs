using System;
using Projeto.Adopet.API.Context;
using Projeto.Adopet.API.Domain;

namespace Projeto.Adopet.API.Service;

public class EventoService : IEventoService
{
    private DataBaseContext _context;

    public EventoService(DataBaseContext context)
    {
        this._context = context;
    }

    public void GenerateFakeData()
    {
        var proprietario = new Cliente
        {
            CPF = "111.111.111-22",
            Nome = "Andre",
            Email = "andre@email.com",
        };
        _context.Add(proprietario);

        var pet = new Pet
        {
            Nome = "Sabio",
            Tipo = TipoPet.Gato,
            Proprietario = proprietario,
        };
        _context.Add(pet);

        _context.SaveChanges();
    }
}
