
namespace PicPay.Desafio.API.Usuarios.Models
{
    public class TransacaoRequest
    {
        public required string EmailDestinatario { get; set; }
        public required decimal Quantia { get; set; }
        public required string Moeda { get; set; }
    }

    public class TransacaoResponse
    {
        public required string Mensagem { get; set; }
    }
}
