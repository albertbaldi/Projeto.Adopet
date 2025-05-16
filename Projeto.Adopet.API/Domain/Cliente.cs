using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Adopet.API.Domain;

public class Cliente
{
    public Cliente()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
