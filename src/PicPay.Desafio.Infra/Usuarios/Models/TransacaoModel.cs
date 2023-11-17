
namespace PicPay.Desafio.Infra.Usuarios.Models;

public partial class TransacaoModel
{
    public int IdTransacao { get; set; }

    public int IdUsuario { get; set; }

    public DateTime DataTransacao { get; set; }

    public decimal Quantia { get; set; }

    public string Moeda { get; set; } = null!;

    public bool TipoOperacao { get; set; }

    public short Status { get; set; }

}
