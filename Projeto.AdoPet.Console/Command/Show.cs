using System;
using Projeto.AdoPet.Console.Util;

namespace Projeto.AdoPet.Console.Command;

public class Show : IComando
{
    public Task ExecutarAsync(string[] args)
    {
        this.ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]);
        return Task.CompletedTask;
    }
    
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
