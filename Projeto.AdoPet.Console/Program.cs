
using Projeto.AdoPet.Console.Command;


ComandosDoSistema comandos = new();

Console.ForegroundColor = ConsoleColor.Green;

try
{
    string comando = args[0].Trim();
    IComando? cmd = comandos[comando];
    if (cmd is not null) await cmd.ExecutarAsync(args);
    else System.Console.WriteLine($"Comando inválido!");
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