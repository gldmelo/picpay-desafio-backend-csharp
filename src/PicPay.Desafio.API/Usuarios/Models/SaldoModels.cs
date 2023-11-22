
namespace PicPay.Desafio.API.Usuarios.Models
{
    public class SaldoResponse
    {
        public required string Mensagem{get; set;}
        public required decimal Saldo { get; set; }
        public required string Moeda { get; set; }
    }
}
