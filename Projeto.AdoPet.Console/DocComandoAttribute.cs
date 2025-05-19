using System;

namespace Projeto.AdoPet.Console;

[AttributeUsage(AttributeTargets.Class)]
public class DocComandoAttribute : Attribute
{
    public string Instrucao { get; }
    public string Documentacao { get; }
    
    public DocComandoAttribute(string instrucao, string documentacao)
    {
        this.Instrucao = instrucao;
        this.Documentacao = documentacao;
    }
}
