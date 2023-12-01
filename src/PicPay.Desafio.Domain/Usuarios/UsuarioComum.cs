using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Domain.Usuarios
{
    public class UsuarioComum : Usuario
    {
        public UsuarioComum(int id, string nomeCompleto, Email email, DocumentoIdentificacao documento, Dinheiro saldoUsuario)
            : base(id, nomeCompleto, email, documento, saldoUsuario)
        {

        }
    }
}