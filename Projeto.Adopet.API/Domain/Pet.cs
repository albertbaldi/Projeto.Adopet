using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Adopet.API.Domain;

public class Pet
{

    [Key]
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public TipoPet Tipo { get; set; }
    public Cliente? Proprietario { get; set; }
}
