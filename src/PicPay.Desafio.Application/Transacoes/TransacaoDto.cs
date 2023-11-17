
namespace PicPay.Desafio.Application.Transacoes
{
    public class TransacaoDto
    {
        public int IdRemetente { get; set; }
        public string EmailDestinatario { get; set; }
        public decimal Quantia { get; set; }
        public string Moeda { get; set; }
    }
}
