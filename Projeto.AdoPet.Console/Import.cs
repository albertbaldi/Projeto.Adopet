using System;

namespace Projeto.AdoPet.Console;

[DocComando("import", "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets")]
public class Import
{
    public async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
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
