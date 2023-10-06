using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Domain.Entidades
{
    public abstract class Usuario
    {
        public string NomeCompleto { get; }
        public Email Email { get; }
        public string Senha { get; }

        public DocumentoIdentificacao Documento { get; }

        public Carteira Carteira { get; set; }

        public Usuario() { }

        public Usuario(string nomeCompleto, Email email, DocumentoIdentificacao documento)
        {
            if (string.IsNullOrEmpty(nomeCompleto))
                throw new ArgumentNullException("Nome não pode ser nulo ou inválido");

            if (documento == null)
                throw new ArgumentNullException("Documento não informado!");

            NomeCompleto = nomeCompleto;
            Documento = documento;
        }

        
    }
}
