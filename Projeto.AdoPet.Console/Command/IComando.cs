using System;

namespace Projeto.AdoPet.Console.Command;

public interface IComando
{
    Task ExecutarAsync(string[] args);
}
