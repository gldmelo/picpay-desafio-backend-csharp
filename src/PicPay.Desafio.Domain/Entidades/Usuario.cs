using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Domain.Entidades
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; } = null!;
        public Email Email { get; } = null!;
        public string Senha { get; } = null!;
        public DocumentoIdentificacao Documento { get; } = null!;
        public Carteira Carteira { get; set; } = null!;

        public Usuario(int id, string nomeCompleto, Email email, DocumentoIdentificacao documento, Dinheiro saldoUsuario)
        {
            if (id <= 0)
                throw new Exception("O identificador do usuário não pode ser menor ou igual a zero.");
            
            if (string.IsNullOrEmpty(nomeCompleto))
                throw new ArgumentNullException("Nome não pode ser nulo ou inválido.");

            if (documento == null)
                throw new ArgumentNullException("Documento não informado.");

            Id = id;
            NomeCompleto = nomeCompleto;
            Documento = documento;
            Carteira = new Carteira(saldoUsuario);
        }

        /// <summary>
        /// Retorna o saldo em conta
        /// </summary>
        public Dinheiro Saldo => Carteira.Saldo;

    }
}
