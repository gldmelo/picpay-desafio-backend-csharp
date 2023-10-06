
namespace PicPay.Desafio.Domain.ValueObjects
{
    public class Cpf : DocumentoIdentificacao
    {
        public Cpf(string numero) : base(numero, "CPF")
        {

        }

        protected override bool IsDocumentoValido(string numero)
        {
            return true;
        }
    }
}
