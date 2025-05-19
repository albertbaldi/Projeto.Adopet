using System;

namespace Projeto.AdoPet.Console;

public class Show
{
    internal void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
    {
        var leitor = new LeitorDeArquivo();

        var pets = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);

        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
}
