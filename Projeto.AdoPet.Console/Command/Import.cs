using System;
using Projeto.AdoPet.Console.Model;
using Projeto.AdoPet.Console.Service;
using Projeto.AdoPet.Console.Util;

namespace Projeto.AdoPet.Console.Command;

[DocComando("import", "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets")]
public class Import : IComando
{
    public async Task ExecutarAsync(string[] args)
    {
        await this.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
    }

    private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        var leitor = new LeitorDeArquivo();
        List<Pet> pets = leitor.RealizaLeitura(caminhoDoArquivoDeImportacao);

        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);

            try
            {
                var httpCreatePet = new HttpClientPet();
                await httpCreatePet.CreatePetAsync(pet);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        System.Console.WriteLine("Importação concluída!");
    }
}
