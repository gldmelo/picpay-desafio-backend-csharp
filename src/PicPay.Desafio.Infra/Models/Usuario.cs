using System;
using System.Collections.Generic;

namespace PicPay.Desafio.Infra.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Email { get; set; } = null!;

    public string NomeCompleto { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Documento { get; set; } = null!;

    public virtual ICollection<Transacao> Transacaos { get; set; } = new List<Transacao>();
}
