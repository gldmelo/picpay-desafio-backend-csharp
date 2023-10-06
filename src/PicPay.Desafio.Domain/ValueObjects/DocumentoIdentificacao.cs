
namespace PicPay.Desafio.Domain.ValueObjects
{
    public abstract class DocumentoIdentificacao
    {
        public string Tipo { get; }
        public string Numero { get; }

        protected DocumentoIdentificacao(string numero, string tipo)
        {
            if (string.IsNullOrEmpty(numero))
                throw new ArgumentNullException("Documento não pode ser nulo ou vazio.");

            if (!IsDocumentoValido(numero))
                throw new ArgumentException("Documento inválido!");

            Numero = numero;
        }

        protected abstract bool IsDocumentoValido(string numero);
    }
}
