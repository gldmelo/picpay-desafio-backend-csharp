using System;
using System.Collections.Generic;

namespace PicPay.Desafio.Infra.Models;

public partial class Transacao
{
    public int IdTransacao { get; set; }

    public int IdUsuario { get; set; }

    public DateTime DataTransacao { get; set; }

    public decimal Quantia { get; set; }

    public string Moeda { get; set; } = null!;

    public bool TipoOperacao { get; set; }

    public short Status { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
