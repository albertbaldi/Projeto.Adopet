using System;

namespace Projeto.AdoPet.Console.Model;

public class Pet
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public TipoPet Tipo { get; set; }

    public Pet(Guid id, string? nome, TipoPet tipo)
    {
        this.Id = id;
        this.Nome = nome;
        this.Tipo = tipo;
    }
    public override string ToString()
    {
        return $"{this.Id} - {this.Nome} - {this.Tipo}";
    }
}
