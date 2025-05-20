using System;
using Projeto.AdoPet.Console.Model;
using Projeto.AdoPet.Console.Service;

namespace Projeto.AdoPet.Console.Command;

[DocComando("list", "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet")]
public class List : IComando
{
    public Task ExecutarAsync(string[] args)
    {
        return this.ListaDadosPetsDaAPIAsync();
    }

    internal async Task ListaDadosPetsDaAPIAsync()
    {
        var httpListPet = new HttpClientPet();

        IEnumerable<Pet>? pets = await httpListPet.ListPetsAsync();
        System.Console.WriteLine("---- LISTA DE PETS IMPORTADOS NO SISTEMA ----");

        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
}
