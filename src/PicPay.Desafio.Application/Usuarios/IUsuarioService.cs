using FluentResults;
using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Usuarios
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Obtém o saldo do usuário
        /// </summary>
        public Result<Dinheiro> ObterSaldo(int idUsuario);
    }
}
