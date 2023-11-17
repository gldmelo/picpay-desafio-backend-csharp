using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Usuarios
{
    public interface IUsuarioService
    {
        //public UsuarioDto ObterUsuarioByEmail(string email);

        /// <summary>
        /// Obtém o saldo do usuário
        /// </summary>
        public Dinheiro ObterSaldo(string emailUsuario);

    }
}
