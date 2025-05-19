
using Projeto.AdoPet.Console;

HttpClient client = ConfigureHttpClient("http://localhost:5059");

Console.ForegroundColor = ConsoleColor.Green;

try
{
    string comando = args[0].Trim();
    switch (comando)
    {
        case "import":
            var import = new Import();
            await import.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
            break;
        case "help":
            var help = new Help();
            help.ExibeDocumentacao(parametros: args);
            break;
        case "show":
            var show = new Show();
            show.ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]);
            break;
        case "list":
            var list = new List();
            await list.ListaDadosPetsDaAPIAsync();
            break;
        default:
            System.Console.WriteLine($"Comando inválido!");
            break;

    }
}
catch (System.Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    System.Console.WriteLine($"Aconteceu uma exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}

HttpClient ConfigureHttpClient(string url)
{
    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    client.BaseAddress = new Uri(url);

    return client;
}