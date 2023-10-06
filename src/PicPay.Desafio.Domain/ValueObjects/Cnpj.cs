
namespace PicPay.Desafio.Domain.ValueObjects
{
    public class Cnpj : DocumentoIdentificacao
    {
        public Cnpj(string numero) : base(numero, "CNPJ")
        {
            
        }

        protected override bool IsDocumentoValido(string numero)
        {
            return true;
        }
    }
}
