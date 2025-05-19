using System;

namespace Projeto.AdoPet.Console;

[DocComando("list", "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet")]
public class List
{
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
