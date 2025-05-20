using System;

namespace Projeto.AdoPet.Console.Command;

public class ComandosDoSistema
{
    private Dictionary<string, IComando> comandosDoSistema = new()
    {
        {"help", new Help() },
        {"import", new Import() },
        {"list", new List() },
        {"show", new Show() },
    };
    
    public IComando? this [string key] => comandosDoSistema.ContainsKey(key) ? comandosDoSistema[key] : null;
}
