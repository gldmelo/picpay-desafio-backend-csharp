namespace PicPay.Desafio.API.Usuarios
{
    public class TransacaoRequest
    {
        public string EmailDestinatario { get; set; }
        public decimal Quantia { get; set; }
        public string Moeda { get; set; }
    }

    public class TransacaoResponse
    {
        public string Status { get; set; }
    }
}
