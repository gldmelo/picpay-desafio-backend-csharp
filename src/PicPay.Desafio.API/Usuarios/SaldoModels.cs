
namespace PicPay.Desafio.API.Usuarios
{
    public class SaldoRequest
    {
        public string Email { get; set; }
    }

    public class SaldoResponse
    {
        public decimal Saldo { get; set; }
        public string Moeda { get; set; }
    }
}
