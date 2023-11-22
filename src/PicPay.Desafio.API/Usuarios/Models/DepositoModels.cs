
namespace PicPay.Desafio.API.Usuarios.Models
{
    public class DepositoRequest
    {
        public required decimal Quantia { get; set; }
        public required string Moeda { get; set; }
    }

    public class DepositoResponse
    {
        public required string Mensagem { get; set; }
    }

}
