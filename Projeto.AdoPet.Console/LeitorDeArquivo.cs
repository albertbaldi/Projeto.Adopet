using System;

namespace Projeto.AdoPet.Console;

public class LeitorDeArquivo
{
    public List<Pet> RealizaLeitura(string caminhoDoArquivoDeImportacao)
    {
        List<Pet> pets = new List<Pet>();
        using var sr = new StreamReader(caminhoDoArquivoDeImportacao);
        System.Console.WriteLine("----- DADOS A SEREM IMPORTADOS -----");
        while (!sr.EndOfStream)
        {
            // separa a linha usando ponto e virgula
            string[]? propriedades = sr.ReadLine().Split(';');

            // cria o objeto Pet a partir da separacao
            Pet pet = new(
                Guid.Parse(propriedades[0]),
                propriedades[1],
                int.Parse(propriedades[2]) == 0 ? TipoPet.Gato : TipoPet.Cachorro
            );

            pets.Add(pet);
        }

        return pets;
    }
}
